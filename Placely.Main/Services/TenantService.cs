using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class TenantService(
    ITenantRepository tenantRepo,
    IPropertyRepository propertyRepo) : ITenantService
{
    public async Task<Tenant> GetByIdAsync(long tenantId)
    {
        return await tenantRepo.GetByIdAsync(tenantId);
    }

    public async Task<Tenant> GetByEmailAsync(string email)
    {
        return await tenantRepo.GetByEmailAsync(email);
    }

    public async Task<Property> AddPropertyToFavouritesAsync(long tenantId, long propertyId)
    {
        var dbTenant = await tenantRepo.GetByIdAsync(tenantId);
        var dbProperty = await propertyRepo.GetByIdAsync(propertyId);
        
        dbTenant.Favourite.Add(dbProperty);
        
        await tenantRepo.UpdateAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        return dbProperty;
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
        var dbTenant = await tenantRepo.GetByIdAsync(tenant.Id);

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

    public async Task<Property> RemovePropertyFromFavouritesAsync(long tenantId, long propertyId)
    {
        var dbTenant = await tenantRepo.GetByIdAsync(tenantId);
        var dbProperty = dbTenant.Favourite.Find(p => p.Id == propertyId);
        if (dbProperty is null) 
            return new Property();
        
        dbTenant.Favourite.Remove(dbProperty);
        
        await tenantRepo.UpdateAsync(dbTenant);
        await tenantRepo.SaveChangesAsync();
        return dbProperty;
    }
}