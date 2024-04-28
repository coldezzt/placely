using Microsoft.EntityFrameworkCore;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class PropertyRepository(AppDbContext appDbContext) 
    : Repository<Property>(appDbContext), IPropertyRepository
{
    public IQueryable<Property> GetPropertiesByFilter(Func<Property, bool>? predicate)
    {
        return predicate is not null 
            ? appDbContext.Properties.Where(b => predicate(b)) 
            : appDbContext.Properties;
    }
    
    public async Task<List<Review>> GetListByPropertyIdAsync(long propertyId)
    {
        var reviews = await appDbContext.Reviews.Where(r => r.PropertyId == propertyId).ToListAsync();
        return reviews;
    }
}