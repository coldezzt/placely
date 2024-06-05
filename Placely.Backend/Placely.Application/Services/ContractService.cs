using EasyDox;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Placely.Application.Common.Exceptions;
using Placely.Application.Common.Models;
using Placely.Application.Common.Options;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;
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

    public async Task<List<string>> GetFileNamesByUserIdsAsync(List<long> userIds)
    {
        var workingDirectoryName = "contracts_" + string.Join("_", userIds.Order());
        var pathToWorkingDirectory =
            Path.Combine(options.Value.ContentRootPath, configurationOptions.Value.PathToContractDirectory, 
                workingDirectoryName);

        if (!Path.Exists(pathToWorkingDirectory))
            throw new ContractServiceException("У этого владельца ещё нет ни одного контракта!");

        return Directory.GetFiles(pathToWorkingDirectory).Select(Path.GetFileName).ToList()!;
    }
    
    public async Task<byte[]> GetFileBytesByIdAsync(long contractId, string fileName)
    {
        logger.Log(LogLevel.Trace, "Begin getting contract file with id: {contractId}", contractId);
        
        var dbContract = await contractRepo.GetByIdAsNoTrackingAsync(contractId);
        if (dbContract.FinalizedDocxFileName is null || dbContract.FinalizedPdfFileName is null)
            throw new ContractServiceException("Файлы контракта ещё не созданы. Попробуйте позднее.");
        
        var absoluteFilePath = Path.Combine(
                options.Value.ContentRootPath, 
                configurationOptions.Value.PathToContractDirectory,
                "contracts_" + string.Join("_", dbContract.Reservation.Participants.Order()),
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
        var dbReservation = await reservationRepository.GetByIdAsync(reservationId);
        var workingDirectoryName = "contracts_" + string.Join("_", dbReservation.Participants.Order());
        var absolutePathToTemplate = Path.Combine(options.Value.ContentRootPath, configurationOptions.Value.PathToTemplate);
        var absolutePathToTemplateFields = Path.Combine(options.Value.ContentRootPath, configurationOptions.Value.PathToTemplateFields);
        var absolutePathToContractDirectory = Path.Combine(options.Value.ContentRootPath, configurationOptions.Value.PathToContractDirectory);
        var absolutePathToWorkingDirectory = Path.Combine(absolutePathToContractDirectory, workingDirectoryName);
        
        // if (!await dadataAddressService.IsAddressExistsAsync(contract.Landlord.ContactAddress))
        //     throw new AddressException("Контактного адреса не существует или он содержит лишние части.");

        if (dbReservation.PaymentAmount is null)
            throw new ArgumentNullException(dbReservation.PaymentAmount.ToString());

        if (dbReservation.PaymentFrequency is null)
            throw new ArgumentNullException(dbReservation.PaymentFrequency);
        
        // Создаём модель контракта
        var reservationModel = new ReservationModel(dbReservation, (decimal) dbReservation.PaymentAmount, dbReservation.PaymentFrequency);
        var contractDate = $"{reservationModel.ContractDate:yy-MM-dd_HH-mm-ss}";
        var docxFileName = $"contract_{contractDate}_{reservationModel.Tenant.Id}.docx";
        var pdfFileName = $"contract_{contractDate}_{reservationModel.Landlord.Id}.pdf";
        
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
                                       "contract based on reservation {reservationId}", reservationModel.Entity.Id);

            // ... и копируем туда шаблон
            File.Copy(absolutePathToTemplate, absolutePathToDoc);
            logger.Log(LogLevel.Trace, "Copied template to directory for " +
                                       "contract based on reservation {reservationId}", reservationModel.Entity.Id);
            
            // Заменяем значения в шаблоне
            var values = await reservationModel.CreateFieldsAsync(absolutePathToTemplateFields);
            errors.AddRange(Docx.MergeInplace(new Engine(), absolutePathToDoc, values)
                .Select(e => e.Accept(new ErrorToRussianString())).ToList());
            logger.Log(LogLevel.Trace, "Filled template to directory for " +
                                       "contract based on reservation {reservationId}", reservationModel.Entity.Id);
            
            // Берём изменённый шаблон и превращаем его в pdf, сохраняя туда же
            var documentCore = DocumentCore.Load(absolutePathToDoc);
            documentCore.Save(absolutePathToPdf);
            logger.Log(LogLevel.Trace, "Converted doc to pdf into directory for " +
                                       "contract based on reservation {reservationId}", reservationModel.Entity.Id);
            
            var contract = new Contract
            {
                ReservationId = reservationId,
                FinalizedDocxFileName = Path.Combine(workingDirectoryName, docxFileName),
                FinalizedPdfFileName = Path.Combine(workingDirectoryName, pdfFileName)
            };
            result = await contractRepo.AddAsync(contract);
            await contractRepo.SaveChangesAsync();
            
            logger.Log(LogLevel.Information, "Successfully created contract " +
                                             "based on reservation {reservationId}", reservationModel.Entity.Id);
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