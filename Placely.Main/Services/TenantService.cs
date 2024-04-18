using LinqKit;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class TenantService(ITenantRepository tenantRepo) : ITenantService
{
    public async Task<Tenant> GetByIdAsync(long tenantId)
    {
        return await tenantRepo.GetByIdAsync(tenantId);
    }

    public async Task<Tenant> GetByEmailAsync(string email)
    {
        return await tenantRepo.GetByEmailAsync(email);
    }

    public async Task<List<Tenant>> GetListByIdsAsync(List<long> tenantIds)
    {
        var tenants = new List<Tenant>();
        foreach (var id in tenantIds)
        {
            var dbTenant = await tenantRepo.GetByIdAsync(id);
            tenants.Add(dbTenant);
        }

        return tenants;
    }
    
    public async Task<List<Property>> GetFavouritePropertiesAsync(long tenantId)
    {
        return (await GetByIdAsync(tenantId)).Favourite;
    }
    
    // TODO: Кажется что логика слишком простая
    public async Task<Tenant> ChangeSettingsAsync(Tenant tenant)
    {
        var dbTenant = await GetByEmailAsync(tenant.Email);

        dbTenant.Name = tenant.Name;
        dbTenant.PhoneNumber = tenant.PhoneNumber;
        dbTenant.AvatarPath = tenant.AvatarPath;
        dbTenant.About = tenant.About;
        dbTenant.Work = tenant.Work;
        
        var result = await tenantRepo.UpdateAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        return result;
    }

    public async Task<Tenant> DeleteAsync(long tenantId)
    {
        var dbTenant = await GetByIdAsync(tenantId);
        var result = await tenantRepo.DeleteAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        return result;
    }
}