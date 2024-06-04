using Dadata.Model;

namespace Placely.WebAPI.Abstractions.Services;

public interface IDadataAddressService
{
    public Task<Address> NormalizeAddressAsync(string address);

    public Task<SuggestResponse<Address>> SuggestAddress(string address);
    
    public Task<bool> IsAddressExistsAsync(string address);
}