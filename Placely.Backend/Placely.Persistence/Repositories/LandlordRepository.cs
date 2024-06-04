using Microsoft.Extensions.Logging;
using Placely.Application.Abstractions.Repositories;
using Placely.Domain.Entities;

namespace Placely.Persistence.Repositories;

public class LandlordRepository(
    ILogger<LandlordRepository> logger, AppDbContext dbContext) 
    : Repository<Landlord>(logger, dbContext), ILandlordRepository
{
    
}