using LinqKit;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;
using Placely.Data.Models;
using Placely.Main.Exceptions;

namespace Placely.Main.Services;

public class PropertyService(
    ILogger<PropertyService> logger,
    ILandlordRepository landlordRepo,
    IPropertyRepository propertyRepo,
    IDadataAddressService dadataAddressService) : IPropertyService
{
    public async Task<Property> GetByIdAsync(long propertyId)
    {
        return await propertyRepo.GetByIdAsync(propertyId);
    }
    
    public async Task<Property> AddAsync(Property property)
    {
        logger.Log(LogLevel.Trace, "Begin adding a property: {@property}", property);

        var address = property.Address;
        var parsedAddress = await dadataAddressService.NormalizeAddressAsync(address);
        if (parsedAddress.unparsed_parts != null)
            throw new AddressException("Адрес содержит части, которые не могут быть нормализованы.");

        var dbLandlord = await landlordRepo.GetByIdAsync(property.OwnerId);
        if (dbLandlord.ContactAddress is null or "")
            throw new AddressException("Контактный адрес не может быть пуст.");
        
        var dbEntity = await propertyRepo.AddAsync(property);
        await propertyRepo.SaveChangesAsync();

        logger.Log(LogLevel.Information, "Successfully added a property: {@property}", property);
        return dbEntity;
    }

    public async Task<Property> UpdateAsync(Property property)
    {
        logger.Log(LogLevel.Trace, "Begin updating a property: {@property}", property);

        var address = property.Address;
        var parsedAddress = await dadataAddressService.NormalizeAddressAsync(address);
        if (parsedAddress.unparsed_parts != null)
            throw new AddressException("Адрес содержит части, которые не могут быть нормализованы.");
        
        var dbEntity = await propertyRepo.UpdateAsync(property);
        await propertyRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Information, "Successfully updated a property: {@property}", property);
        return dbEntity;
    }

    public async Task<Property> DeleteAsync(long propertyId)
    {
        var property = await propertyRepo.GetByIdAsync(propertyId);
        var dbEntity = await propertyRepo.DeleteAsync(property);
        await propertyRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Information, "Successfully deleted property: {@property}", property);
        return dbEntity;
    }

    public Task<List<Property>> GetChunkByFilterAsync(
        Dictionary<SearchParameter, string> searchParameters,
        int extraLoadNumber,
        int amount = 10)
    {
        // Сборка предиката
        var builder = PredicateBuilder.New<Property>();

        if (searchParameters.TryGetValue(SearchParameter.Category, out var value)
            && Enum.TryParse<PropertyType>(value, out var propertyType))
            builder = builder.And(b => b.Type.Equals(propertyType));

        var predicate = builder.Compile();
        
        // Получение данных
        var properties = propertyRepo.GetPropertiesByFilter(predicate).ToList();

        // Сортировка
        var ordered = properties.OrderBy(p => p.Id);
        if (searchParameters.TryGetValue(SearchParameter.New, out value)
            && bool.TryParse(value, out var isNew))
            ordered = isNew
                ? ordered.OrderByDescending(static p => p.PublicationDate)
                : ordered.OrderBy(p => p.PublicationDate);

        if (searchParameters.TryGetValue(SearchParameter.HighRated, out value)
            && bool.TryParse(value, out var isHighRated))
            ordered = isHighRated
                ? ordered.ThenByDescending(static p => p.Rating)
                : ordered.ThenBy(b => b.Rating);
        
        // Пагинация
        var paginated = ordered.Skip((extraLoadNumber - 1) * amount).Take(amount).ToList();
        
        return Task.FromResult(paginated);
    }
    
    public async Task<List<Review>> GetReviewsListByIdAsync(long propertyId, int extraLoadNumber = 0)
    {
        logger.Log(LogLevel.Trace, "Begin getting review list of property with id: {propertyId}", propertyId);

        var reviews = await propertyRepo.GetReviewsListByIdAsync(propertyId);
        var result = reviews
            .OrderByDescending(static r => r.Date)
            .Skip((extraLoadNumber - 1) * 10)
            .Take(10)
            .ToList();

        logger.Log(LogLevel.Information, "Successfully got review list of property with id: {propertyId}", propertyId);
        return result;
    }

    public async Task<List<string>> GetAddressSuggestionAsync(string address)
    {
        var response = await dadataAddressService.SuggestAddress(address);
        var suggestions = response.suggestions.Select(static s => s.value).ToList();
        return suggestions;
    }
}