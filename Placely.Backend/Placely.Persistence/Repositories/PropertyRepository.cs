using LinqKit.Core;
using Microsoft.Extensions.Logging;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Entities;

namespace Placely.Persistence.Repositories;

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
}