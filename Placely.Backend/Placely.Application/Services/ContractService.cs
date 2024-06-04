using EasyDox;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Placely.Application.Abstractions.Repositories;
using Placely.Application.Exceptions;
using Placely.Application.Models;
using Placely.Application.Options;
using Placely.Domain.Abstractions.Services;
using Placely.Domain.Entities;
using SautinSoft.Document;

namespace Placely.Application.Services;

public class ContractService(
    ILogger<ContractService> logger,
    IOptions<CommonOptions> options,
    IOptions<ContractServiceOptions> configurationOptions,
    IReservationRepository reservationRepository,
    IContractRepository contractRepo,
    IDadataAddressService dadataAddressService
    ) : IContractService
{
    public async Task<Reservation> GetReservationByIdAsync(long reservationId)
    {
        return await reservationRepository.GetByIdAsNoTrackingAsync(reservationId);
    }
    
    public async Task<Contract> GetByIdAsNoTrackingAsync(long contractId)
    {
        return await contractRepo.GetByIdAsNoTrackingAsync(contractId);
    }

    public async Task<List<string>> GetFileNamesListByLandlordAndTenantIdAsync(long landlordId, long tenantId)
    {
        var workingDirectoryName = "contracts_" + string.Join("_", new List<long> {landlordId, tenantId}.Order());
        var pathToWorkingDirectory =
            Path.Combine(options.Value.ContentRootPath, configurationOptions.Value.PathToContractDirectory, 
                workingDirectoryName);

        if (!Path.Exists(pathToWorkingDirectory))
            throw new ContractServiceException("У этого владельца ещё нет ни одного контракта!");

        return Directory.GetFiles(pathToWorkingDirectory).Select(s => Path.GetFileName(s)).ToList();
    }
    
    public async Task<byte[]> GetFileBytesByIdAsync(long contractId, string fileName)
    {
        logger.Log(LogLevel.Trace, "Begin getting contract file with id: {contractId}", contractId);
        var contract = await contractRepo.GetByIdAsNoTrackingAsync(contractId);
        if (contract.FinalizedDocxFileName is null || contract.FinalizedPdfFileName is null)
            throw new ContractServiceException("Файлы контракта ещё не созданы. Попробуйте позднее.");
        
        var absoluteFilePath = Path.Combine(
            options.Value.ContentRootPath, 
            configurationOptions.Value.PathToContractDirectory,
            "contracts_" + string.Join("_", new List<long> {contract.Reservation.LandlordId, contract.Reservation.TenantId}.Order()),
            fileName
            );
        if (!Path.Exists(absoluteFilePath))
        {
            logger.Log(LogLevel.Debug,
                "Contract file with id: {contractId} is not found. Returning empty byte array.", contractId);
            return Array.Empty<byte>();
        }
        var fileBytes = await File.ReadAllBytesAsync(absoluteFilePath);
        
        logger.Log(LogLevel.Debug, "Successfully got contract file with id: {contractId}.", contractId);
        return fileBytes;
    }
    
    public async Task<Contract> GenerateAsync(long reservationId)
    {
        logger.Log(LogLevel.Trace, "Begin creating contract based on reservation {reservationId}", reservationId);
        // Достаём данные и "сокращаем переменные" (для читабельности)
        var reservation = await reservationRepository.GetByIdAsync(reservationId);
        var workingDirectoryName = "contracts_" + string.Join("_", new List<long> {reservation.LandlordId, reservation.TenantId}.Order());
        var absolutePathToTemplate = Path.Combine(options.Value.ContentRootPath, configurationOptions.Value.PathToTemplate);
        var absolutePathToTemplateFields = Path.Combine(options.Value.ContentRootPath, configurationOptions.Value.PathToTemplateFields);
        var absolutePathToContractDirectory = Path.Combine(options.Value.ContentRootPath, configurationOptions.Value.PathToContractDirectory);
        var absolutePathToWorkingDirectory = Path.Combine(absolutePathToContractDirectory, workingDirectoryName);
        
        // if (!await dadataAddressService.IsAddressExistsAsync(contract.Landlord.ContactAddress))
        //     throw new AddressException("Контактного адреса не существует или он содержит лишние части.");

        // Создаём модель контракта
        var reservationModel = new ReservationModel(reservation, reservation.PaymentAmount, reservation.PaymentFrequency);
        var contractDate = $"{reservationModel.ContractDate:yy-MM-dd_HH-mm-ss}";
        var docxFileName = $"contract_{contractDate}_{reservation.TenantId}.docx";
        var pdfFileName = $"contract_{contractDate}_{reservation.TenantId}.pdf";
        
        var absolutePathToDoc = Path.Combine(absolutePathToWorkingDirectory, docxFileName);
        var absolutePathToPdf = Path.Combine(absolutePathToWorkingDirectory, pdfFileName);

        List<string> errors = new();
        var result = new Contract();
        
        // Здесь блок try-catch, потому что это так называемая "опасная зона"
        // Мы взаимодействуем с физическими файлами снаружи нашей программы (которые не под нашим контролем),
        // поэтому я ловлю ошибку здесь же, и откатываю изменения если такие есть.
        try
        {
            // Создаём новую папку...
            if (!Directory.Exists(absolutePathToWorkingDirectory))
                Directory.CreateDirectory(absolutePathToWorkingDirectory);
            logger.Log(LogLevel.Trace, "Created directory for " +
                                       "contract based on reservation {reservationId}", reservation.Id);

            // ... и копируем туда шаблон
            File.Copy(absolutePathToTemplate, absolutePathToDoc);
            logger.Log(LogLevel.Trace, "Copied template to directory for " +
                                       "contract based on reservation {reservationId}", reservation.Id);
            
            // Заменяем значения в шаблоне
            var values = await reservationModel.CreateFieldsAsync(absolutePathToTemplateFields);
            errors.AddRange(Docx.MergeInplace(new Engine(), absolutePathToDoc, values)
                .Select(e => e.Accept(new ErrorToRussianString())).ToList());
            logger.Log(LogLevel.Trace, "Filled template to directory for " +
                                       "contract based on reservation {reservationId}", reservation.Id);
            
            // Берём изменённый шаблон и превращаем его в pdf, сохраняя туда же
            var documentCore = DocumentCore.Load(absolutePathToDoc);
            documentCore.Save(absolutePathToPdf);
            logger.Log(LogLevel.Trace, "Converted doc to pdf into directory for " +
                                       "contract based on reservation {reservationId}", reservation.Id);
            
            var contract = new Contract
            {
                ReservationId = reservationId,
                FinalizedDocxFileName = Path.Combine(workingDirectoryName, docxFileName),
                FinalizedPdfFileName = Path.Combine(workingDirectoryName, pdfFileName)
            };
            result = await contractRepo.AddAsync(contract);
            await contractRepo.SaveChangesAsync();
            
            logger.Log(LogLevel.Information, "Successfully created contract " +
                                             "based on reservation {reservationId}", reservation.Id);
        }
        catch (Exception ex)
        {
            // Подчищаем за собой мусор
            File.Delete(absolutePathToDoc);
            File.Delete(absolutePathToPdf);
            
            // Выбрасываемся к глобальному обработчику
            throw new ContractServiceException(ex.Message + string.Join(" | ", errors)); 
        }
        
        return result;
    }
}