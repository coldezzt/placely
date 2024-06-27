using Dadata;
using Dadata.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Placely.Domain.Interfaces.Services;

namespace Placely.Infrastructure.Services;

public class DadataAddressService : IDadataAddressService
{
    private ILogger<DadataAddressService> Logger { get; }
    private IConfigurationSection DadataConfig { get; }
    private string? DadataToken { get; }
    private string? DadataSecret { get; }
    
    public DadataAddressService(ILogger<DadataAddressService> logger, IConfiguration configuration)
    {
        Logger = logger;
        DadataConfig = configuration.GetSection("ExternalApi:Dadata");
        DadataToken = DadataConfig["Token"];
        DadataSecret = DadataConfig["Secret"];
    }
    
    public async Task<Address> NormalizeAddressAsync(string address)
    {
        var client = new CleanClientAsync(DadataToken, DadataSecret);
        var clean = await client.Clean<Address>(address);

        Logger.Log(LogLevel.Debug, "Successfully cleaned address: {address}", address);
        
        return clean;
    }

    public async Task<SuggestResponse<Address>> SuggestAddress(string address)
    {
        var client = new SuggestClientAsync(DadataToken);
        var suggested = await client.SuggestAddress(address);
        
        Logger.Log(LogLevel.Debug, "Successfully suggested address: {address}", address);
        
        return suggested;
    }

    public async Task<bool> IsAddressExistsAsync(string address)
    {
        var normalizeAddress = await NormalizeAddressAsync(address);
        var isSuccess = normalizeAddress.unparsed_parts == null;
        
        Logger.Log(
            LogLevel.Debug,
            isSuccess 
                ? "Successfully find address: {address}" 
                : "Address doesn't exist: {address}", 
            address);
        
        return isSuccess;
    }
}