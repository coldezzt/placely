using Dadata;
using Dadata.Model;
using Placely.Data.Abstractions.Services;

namespace Placely.Main.Services;

public class DadataAddressService : IDadataAddressService
{
    private IConfigurationSection DadataConfig { get; }
    private string? DadataToken { get; }
    private string? DadataSecret { get; }
    
    public DadataAddressService(IConfiguration configuration)
    {
        DadataConfig = configuration.GetSection("ExternalApi:Dadata");
        DadataToken = DadataConfig["Token"];
        DadataSecret = DadataConfig["Secret"];
    }
    
    public Task<Address> NormalizeAddressAsync(string address)
    {
        var client = new CleanClientAsync(DadataToken, DadataSecret);
        return client.Clean<Address>(address);
    }

    public Task<SuggestResponse<Address>> SuggestAddress(string address)
    {
        var client = new SuggestClientAsync(DadataToken);
        return client.SuggestAddress(address);
    }

    public async Task<bool> IsAddressExistsAsync(string address)
    {
        var normalizeAddress = await NormalizeAddressAsync(address);
        return normalizeAddress.unparsed_parts != null;
    }
}