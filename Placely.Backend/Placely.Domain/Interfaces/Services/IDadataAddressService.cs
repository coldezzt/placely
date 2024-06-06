using Dadata.Model;

namespace Placely.Domain.Interfaces.Services;

public interface IDadataAddressService
{
    Task<Address> NormalizeAddressAsync(string address);

    Task<SuggestResponse<Address>> SuggestAddress(string address);
    
    Task<bool> IsAddressExistsAsync(string address);
}