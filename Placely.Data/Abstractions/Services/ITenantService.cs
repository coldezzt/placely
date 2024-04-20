using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface ITenantService
{
    public Task<Tenant> GetByIdAsync(long tenantId);
    public Task<Tenant> GetByEmailAsync(string email);
    public Task<List<Tenant>> GetListByIdsAsync(List<long> tenantIds);
    public Task<Tenant> ChangeSettingsAsync(Tenant tenant); 
    public Task<List<Property>> GetFavouritePropertiesAsync(long tenantId);
    public Task<Tenant> DeleteAsync(long tenantId);
}