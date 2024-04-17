using System.Security.Claims;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;
using Placely.Data.Models;
using Placely.Main.Services.Utils;

namespace Placely.Main.Services;

public class AuthorizationService(
    ITenantRepository tenantRepo,
    IJwtTokenService jwtTokenService) : IAuthorizationService
{
    public async Task<string> Authorize(Tenant tenant)
    {
        var dbTenant = await tenantRepo.GetByEmailAsync(tenant.Email);
        if (!PasswordHasher.Validate(dbTenant.Password, tenant.Password))
            return string.Empty;

        var claims = new List<Claim>
        {
            new(CustomClaimTypes.UserId, dbTenant.Id.ToString()),
            new(CustomClaimTypes.UserRole, dbTenant.UserRole.ToString())
        };

        return jwtTokenService.CreateJwtToken(claims);
    }
}