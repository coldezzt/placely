using AutoMapper;
using EasyDox;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;
using Placely.Data.Models;
using Placely.Main.Exceptions;
using SautinSoft.Document;

namespace Placely.Main.Services;

public class ContractService(ILogger<ContractService> logger,
        IReservationRepository reservationRepository,
        IContractRepository contractRepository,
        IHostEnvironment environment,
        IConfiguration configuration,
        IDadataAddressService dadataAddressService,
        IMapper mapper)
    : IContractService
{
    private readonly IConfigurationSection _configuration = configuration.GetSection("ContractGeneration");

    public async Task<Reservation> GetReservationByIdAsync(long reservationId)
    {
        return await reservationRepository.GetByIdAsync(reservationId);
    }
    
    public async Task<Contract> GetContractByIdAsync(long contractId)
    {
        return await contractRepository.GetByIdAsync(contractId);
    }
    
    // TODO: для быстроты работы можно создать задачу на создание документа (hangfire уже подключён)
    // и присвоение его пути в сущности в базе данных, для этого нужно будет создать состояние документа (его готовность)
    public async Task<Contract> GenerateContractAsync(ContractCreationDto dto)
    {
        logger.Log(LogLevel.Trace, "Begin creating contract based on reservation {reservationId}", dto.ReservationId);
        // Достаём данные
        var reservation = await reservationRepository.GetByIdAsync(dto.ReservationId);
        var contract = mapper.Map<Contract>(reservation);

        if (!await dadataAddressService.IsAddressExistsAsync(contract.Landlord.ContactAddress))
            throw new AddressException("Контактного адреса не существует или он содержит лишние части.");
        
        // Создаём сущность-обёртку над контрактом
        var contractModel = new ContractModel(contract, dto.PaymentAmount, dto.PaymentFrequency);
        var contractDate = $"{contractModel.ContractDate:yy-MM-dd_HH-mm-ss}";
        
        // Создаём новую папку...
        var workDir = Path.Combine(environment.ContentRootPath, _configuration["PathToTemplate"]!, 
            $"/contracts_{contract.LandlordId}");
        if (!Directory.Exists(workDir))
            Directory.CreateDirectory(workDir);
        logger.Log(LogLevel.Trace, "Created directory for " +
                                   "contract based on reservation {reservationId}", 
            dto.ReservationId);

        // ... и копируем туда шаблон
        var pathToDoc = Path.Combine(_configuration["PathToTemplate"]!, 
            $"/{workDir}/dated_{contractDate}_with_{contract.TenantId}.docx");
        File.Copy(_configuration["PathToTemplate"]!, pathToDoc);
        logger.Log(LogLevel.Trace, "Copied template to directory for " +
                                   "contract based on reservation {reservationId}", dto.ReservationId);
        
        // Заменяем значения в шаблоне
        var values = await contractModel.CreateFieldsAsync(_configuration["PathToTemplate"]!);
        var errors = Docx.MergeInplace(new Engine(), pathToDoc, values)
            .Select(static e => e.ToString() ?? "").ToList();
        logger.Log(LogLevel.Trace, "Filled template to directory for " +
                                   "contract based on reservation {reservationId}", dto.ReservationId);
        
        if (errors.Any())
            throw new ContractServiceException(errors);
        
        // Берём изменённый шаблон и превращаем его в pdf, сохраняя туда же
        var pathToPdf = Path.Combine(workDir, $"/contract_{contractDate}.pdf");
        var dc = DocumentCore.Load(pathToDoc);
        dc.Save(pathToPdf);
        logger.Log(LogLevel.Trace, "Converted doc to pdf into directory for " +
                                   "contract based on reservation {reservationId}", dto.ReservationId);
        
        contract.FinalizedPathDocx = pathToDoc;
        contract.FinalizedPathPdf = pathToPdf;
        var result = await contractRepository.AddAsync(contract);
        await contractRepository.SaveChangesAsync();
        
        logger.Log(LogLevel.Information, "Successfully created contract " +
                                         "based on reservation {reservationId}", dto.ReservationId);
        return result;
    }
}