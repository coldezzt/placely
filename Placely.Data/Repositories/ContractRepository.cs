using Placely.Data.Abstractions.Repositories;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class ContractRepository : IContractRepository
{
    public Task<Contract> CreateAsync(Contract entity)
    {
        throw new NotImplementedException();
    }

    public Contract Update(Contract entity)
    {
        throw new NotImplementedException();
    }

    public Contract Delete(Contract entity)
    {
        throw new NotImplementedException();
    }

    public Task<Contract?> GetByIdAsync(long entityId)
    {
        throw new NotImplementedException();
    }
}