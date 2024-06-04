using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class ContractRepository(ILogger<ContractRepository> logger, AppDbContext appDbContext) 
    : Repository<Contract>(logger, appDbContext), IContractRepository
{
    
}