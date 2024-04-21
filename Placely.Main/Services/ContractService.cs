using AutoMapper;
using EasyDox;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos.Requests;
using Placely.Data.Entities;
using Placely.Data.Models;
using Placely.Main.Exceptions;
using SautinSoft.Document;

namespace Placely.Main.Services;

public class ContractService(
    IReservationRepository reservationRepository,
    IContractRepository contractRepository,
    IHostEnvironment environment,
    IMapper mapper) : IContractService
{
    // TODO: для быстроты работы можно создать задачу на создание документа (hangfire уже подключён)
    // и присвоение его пути в сущности в базе данных, для этого нужно будет создать состояние документа (его готовность)
    // также нужно добавить в сущности ссылки на документ
    public async Task<Contract> GenerateContractAsync(ContractCreateRequestDto dto)
    {
        // Достаём данные
        var reservation = await reservationRepository.GetByIdAsync(dto.ReservationId);
        var contract = mapper.Map<Contract>(reservation);

        // Создаём сущность-обёртку над контрактом
        var contractModel = new ContractModel(contract, dto.PaymentAmount, dto.PaymentFrequency);
        var contractDate = $"{contractModel.ContractDate:yy-MM-dd_HH-mm-ss}";
        
        // Создаём новую папку...
        var workDir = Path.Combine(environment.ContentRootPath, dto.PathToTemplate, 
            $"/contracts_{contract.LandlordId}");
        if (!Directory.Exists(workDir))
            Directory.CreateDirectory(workDir);
        // ... и копируем туда шаблон
        var pathToDoc = Path.Combine(dto.PathToTemplate, 
            $"/{workDir}/dated_{contractDate}_with_{contract.TenantId}.docx");
        File.Copy(dto.PathToTemplate, pathToDoc);
        
        // Заменяем значения в шаблоне
        var values = await contractModel.CreateFieldsAsync(dto.PathToTemplate);
        var errors = Docx.MergeInplace(new Engine(), pathToDoc, values)
            .Select(e => e.ToString() ?? "").ToList();
        
        if (errors.Any())
            throw new ContractServiceException(errors);
        
        // Берём изменённый шаблон и превращаем его в pdf, сохраняя туда же
        var pathToPdf = Path.Combine(workDir, $"/contract_{contractDate}.pdf");
        var dc = DocumentCore.Load(pathToDoc);
        dc.Save(pathToPdf);
        
        contract.FinalizedPathDocx = pathToDoc;
        contract.FinalizedPathPdf = pathToPdf;
        var result = await contractRepository.AddAsync(contract);
        await contractRepository.SaveChangesAsync();
        
        return result;
    }

    public async Task<Contract> GetContractById(long contractId)
    {
        return await contractRepository.GetByIdAsync(contractId);
    }
}