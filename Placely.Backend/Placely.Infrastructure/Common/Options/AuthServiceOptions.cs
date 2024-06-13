namespace Placely.Infrastructure.Common.Options;

public class AuthServiceOptions
{
    public required string ValidAudience { get; set; }
    public required string ValidIssuer { get; set; }
    public required string Secret { get; set; }
}