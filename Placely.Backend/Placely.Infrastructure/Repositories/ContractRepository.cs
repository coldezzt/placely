using Microsoft.Extensions.Logging;
using Placely.Application.Abstractions.Repositories;
using Placely.Domain.Entities;

namespace Placely.Infrastructure.Repositories;

public class ContractRepository(ILogger<ContractRepository> logger, AppDbContext appDbContext) 
    : Repository<Contract>(logger, appDbContext), IContractRepository
{
    
}