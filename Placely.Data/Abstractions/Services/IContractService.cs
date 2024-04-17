using Placely.Data.Dtos.Requests;
using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface IContractService
{
    public Task<Contract> GenerateContractAsync(ContractCreateRequestDto dto);
}