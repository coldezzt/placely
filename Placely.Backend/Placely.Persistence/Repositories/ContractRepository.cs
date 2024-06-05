using Microsoft.Extensions.Logging;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Entities;

namespace Placely.Persistence.Repositories;

public class ContractRepository(ILogger<ContractRepository> logger, AppDbContext appDbContext) 
    : Repository<Contract>(logger, appDbContext), IContractRepository
{
    
}