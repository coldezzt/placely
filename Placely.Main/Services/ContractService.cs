using AutoMapper;
using EasyDox;
using Microsoft.Extensions.Options;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;
using Placely.Data.Models;
using Placely.Data.Options;
using Placely.Main.Exceptions;
using SautinSoft.Document;

namespace Placely.Main.Services;

public class ContractService(
    ILogger<ContractService> logger,
    IOptions<ApplicationCommonOptions> options,
    IOptions<ContractServiceOptions> configurationOptions,
    IReservationRepository reservationRepository,
    IContractRepository contractRepo,
    IDadataAddressService dadataAddressService,
    IMapper mapper)
    : IContractService
{
    public async Task<Reservation> GetReservationByIdAsync(long reservationId)
    {
        return await reservationRepository.GetByIdAsNoTrackingAsync(reservationId);
    }
    
    public async Task<Contract> GetByIdAsNoTrackingAsync(long contractId)
    {
        return await contractRepo.GetByIdAsNoTrackingAsync(contractId);
    }

    public async Task<List<string>> GetFileNamesListByLandlordIdAsync(long landlordId)
    {
        var workingDirectoryName = $"\\contracts_{landlordId}";
        var pathToWorkingDirectory =
            Path.Combine(options.Value.ContentRootPath, configurationOptions.Value.PathToContractDirectory, 
                workingDirectoryName);

        if (!Path.Exists(pathToWorkingDirectory))
            throw new ContractServiceException("У этого владельца ещё нет ни одного контракта!");

        return Directory.GetFiles(pathToWorkingDirectory).Select(s => Path.GetFileName(s)).ToList();
    }
    
    public async Task<byte[]> GetFileBytesByIdAsync(long contractId, string format = "pdf")
    {
        logger.Log(LogLevel.Trace, "Begin getting contract file with id: {contractId}", contractId);
        var contract = await contractRepo.GetByIdAsNoTrackingAsync(contractId);
        if (contract.FinalizedDocxFileName is null || contract.FinalizedPdfFileName is null)
            throw new ContractServiceException("Файлы контракта ещё не созданы. Попробуйте позднее.");
        
        var fullFilePath = Path.Combine(
            options.Value.ContentRootPath, 
            configurationOptions.Value.PathToContractDirectory, 
            format == "pdf" 
                ? contract.FinalizedPdfFileName 
                : contract.FinalizedDocxFileName
            );
        if (!Path.Exists(fullFilePath))
        {
            logger.Log(LogLevel.Debug,
                "Contract file with id: {contractId} is not found. Returning empty byte array.", contractId);
            return Array.Empty<byte>();
        }
        var fileBytes = await File.ReadAllBytesAsync(fullFilePath);
        
        logger.Log(LogLevel.Debug, "Successfully got contract file with id: {contractId}.", contractId);
        return fileBytes;
    }
    
    public async Task<Contract> GenerateAsync(ContractCreationDto dto)
    {
        logger.Log(LogLevel.Trace, "Begin creating contract based on reservation {reservationId}", dto.ReservationId);
        // Достаём данные
        var reservation = await reservationRepository.GetByIdAsNoTrackingAsync(dto.ReservationId);
        var contract = mapper.Map<Contract>(reservation);

        var workingDirectoryName = $"\\contracts_{contract.LandlordId}";
        var pathToTemplate = Path.Combine(options.Value.ContentRootPath, configurationOptions.Value.PathToTemplate);
        var pathToTemplateFields =
            Path.Combine(options.Value.ContentRootPath, configurationOptions.Value.PathToTemplateFields);
        var pathToContractDirectory =
            Path.Combine(options.Value.ContentRootPath, configurationOptions.Value.PathToContractDirectory);
        var pathToWorkingDirectory = Path.Combine(pathToContractDirectory, workingDirectoryName);
        // if (!await dadataAddressService.IsAddressExistsAsync(contract.Landlord.ContactAddress))
        //     throw new AddressException("Контактного адреса не существует или он содержит лишние части.");
        
        // Создаём сущность-обёртку над контрактом
        var contractModel = new ContractModel(contract, dto.PaymentAmount, dto.PaymentFrequency);
        var contractDate = $"{contractModel.ContractDate:yy-MM-dd_HH-mm-ss}";
        var docxFileName = $"\\contract_{contractDate}_{contract.TenantId}.docx";
        var pdfFileName = $"\\contract_{contractDate}_{contract.TenantId}.pdf";
        
        // Создаём новую папку...
        if (!Directory.Exists(pathToWorkingDirectory))
            Directory.CreateDirectory(pathToWorkingDirectory);
        logger.Log(LogLevel.Trace, "Created directory for " +
                                   "contract based on reservation {reservationId}", 
            dto.ReservationId);

        // ... и копируем туда шаблон
        var pathToDoc = Path.Combine(pathToWorkingDirectory, docxFileName);
        File.Copy(pathToTemplate, pathToDoc);
        logger.Log(LogLevel.Trace, "Copied template to directory for " +
                                   "contract based on reservation {reservationId}", dto.ReservationId);
        
        // Заменяем значения в шаблоне
        var values = await contractModel.CreateFieldsAsync(pathToTemplateFields);
        var errors = Docx.MergeInplace(new Engine(), pathToDoc, values)
            .Select(static e => e.ToString() ?? "").ToList();
        logger.Log(LogLevel.Trace, "Filled template to directory for " +
                                   "contract based on reservation {reservationId}", dto.ReservationId);
        
        if (errors.Any())
            throw new ContractServiceException(string.Join(" | ", errors));
        
        // Берём изменённый шаблон и превращаем его в pdf, сохраняя туда же
        var pathToPdf = Path.Combine(pathToWorkingDirectory, pdfFileName);
        var documentCore = DocumentCore.Load(pathToDoc);
        documentCore.Save(pathToPdf);
        logger.Log(LogLevel.Trace, "Converted doc to pdf into directory for " +
                                   "contract based on reservation {reservationId}", dto.ReservationId);
        
        contract.FinalizedDocxFileName = Path.Combine(workingDirectoryName, docxFileName);
        contract.FinalizedPdfFileName = Path.Combine(workingDirectoryName, docxFileName);
        var result = await contractRepo.AddAsync(contract);
        await contractRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Information, "Successfully created contract " +
                                         "based on reservation {reservationId}", dto.ReservationId);
        return result;
    }
}