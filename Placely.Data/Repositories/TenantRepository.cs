using Microsoft.EntityFrameworkCore;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;
using Placely.Data.Exceptions;

namespace Placely.Data.Repositories;

public class TenantRepository(AppDbContext appDbContext) 
    : Repository<Tenant>(appDbContext), ITenantRepository
{
    public async Task<Tenant> GetByEmailAsync(string email)
    {
        var result = await appDbContext.Tenants.FirstOrDefaultAsync(t => t.Email == email);
        if (result is null)
            throw new EntityNotFoundException(typeof(Tenant), email);
        
        return result;
    }

    public async Task<Tenant?> TryGetByEmailAsync(string email)
    {
        var result = await appDbContext.Tenants.FirstOrDefaultAsync(t => t.Email == email);
        return result;
    }

    public async Task<Tenant> AddOrUpdateAsync(Tenant tenant)
    {
        var dbTenant = await appDbContext.Tenants.FirstOrDefaultAsync(t => t.Email == tenant.Email);
        var resultTenant = dbTenant is null 
            ? await appDbContext.Tenants.AddAsync(tenant)
            : appDbContext.Tenants.Update(tenant);

        return resultTenant.Entity;
    }
}