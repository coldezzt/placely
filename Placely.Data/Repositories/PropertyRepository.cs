using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class PropertyRepository(AppDbContext appDbContext) 
    : Repository<Property>(appDbContext), IPropertyRepository
{
    
}