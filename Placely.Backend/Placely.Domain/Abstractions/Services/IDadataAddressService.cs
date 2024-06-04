using Dadata.Model;

namespace Placely.Domain.Abstractions.Services;

public interface IDadataAddressService
{
    public Task<Address> NormalizeAddressAsync(string address);

    public Task<SuggestResponse<Address>> SuggestAddress(string address);
    
    public Task<bool> IsAddressExistsAsync(string address);
}