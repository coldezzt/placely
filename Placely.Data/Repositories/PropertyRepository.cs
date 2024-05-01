using LinqKit.Core;
using Microsoft.EntityFrameworkCore;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class PropertyRepository(ILogger<PropertyRepository> logger, AppDbContext appDbContext) 
    : Repository<Property>(logger, appDbContext), IPropertyRepository
{
    public IEnumerable<Property> GetPropertiesByFilter(Func<Property, bool>? predicate)
    {
        logger.Log(LogLevel.Debug, "Begin getting properties list with predicate");

        var result = predicate is not null 
            ? appDbContext.Properties.AsExpandable().AsEnumerable().Where(predicate)
            : appDbContext.Properties;
        
        logger.Log(LogLevel.Debug, "Successfully got properties list with predicate");
        return result;
    }
    
    public async Task<List<Review>> GetReviewsListByIdAsync(long propertyId)
    {
        logger.Log(LogLevel.Debug, $"Begin getting reviews list of property with Id: {propertyId}");
        
        var reviews = await appDbContext.Reviews.Where(r => r.PropertyId == propertyId).ToListAsync();
        
        logger.Log(LogLevel.Debug, $"Successfully got reviews list of property with Id: {propertyId}");
        return reviews;
    }
}