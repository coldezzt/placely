using System.Security.Claims;

namespace Placely.Data.Abstractions.Services;

public interface IJwtTokenService
{
    public string CreateJwtToken(IEnumerable<Claim> claims);
}