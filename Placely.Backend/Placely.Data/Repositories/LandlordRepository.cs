using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class LandlordRepository(
    ILogger<LandlordRepository> logger, AppDbContext dbContext) 
    : Repository<Landlord>(logger, dbContext), ILandlordRepository
{
    
}