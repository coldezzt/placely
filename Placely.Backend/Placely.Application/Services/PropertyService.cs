using LinqKit;
using Microsoft.Extensions.Logging;
using Placely.Application.Abstractions.Repositories;
using Placely.Application.Exceptions;
using Placely.Domain.Abstractions.Services;
using Placely.Domain.Entities;
using Placely.Domain.Enums;

namespace Placely.Application.Services;

public class PropertyService(
    ILogger<PropertyService> logger,
    IPropertyRepository propertyRepo,
    IDadataAddressService dadataAddressService) : IPropertyService
{
    public async Task<Property> GetByIdAsNoTrackingAsync(long propertyId)
    {
        return await propertyRepo.GetByIdAsNoTrackingAsync(propertyId);
    }
    
    public async Task<Property> AddAsync(Property property)
    {
        logger.Log(LogLevel.Trace, "Begin adding a property: {@property}", property);

        var address = property.Address;
        var parsedAddress = await dadataAddressService.NormalizeAddressAsync(address);
        if (parsedAddress.unparsed_parts != null)
            throw new AddressException("Адрес содержит части, которые не могут быть нормализованы.");

        // var dbLandlord = await landlordRepo.GetByIdAsync(property.OwnerId);
        // if (dbLandlord.ContactAddress is null or "")
        //    throw new AddressException("Контактный адрес не может быть пуст.");
        
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

        var dbProperty = await propertyRepo.GetByIdAsNoTrackingAsync(property.Id);
        dbProperty.Description = property.Description;
        dbProperty.PriceList = property.PriceList;

        var updatedProperty = await propertyRepo.UpdateAsync(dbProperty);
        await propertyRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Information, "Successfully updated a property: {@property}", updatedProperty);
        return updatedProperty;
    }

    public async Task<Property> DeleteAsync(long propertyId)
    {
        var property = await propertyRepo.GetByIdAsNoTrackingAsync(propertyId);
        var dbEntity = await propertyRepo.DeleteAsync(property);
        await propertyRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Information, "Successfully deleted property: {@property}", property);
        return dbEntity;
    }

    public Task<List<Property>> GetChunkByFilterAsync(
        Dictionary<SearchParameterType, string> searchParameters,
        int extraLoadNumber,
        int amount = 10)
    {
        // Сборка предиката
        var builder = PredicateBuilder.New<Property>(true);

        if (searchParameters.TryGetValue(SearchParameterType.Category, out var value)
            && Enum.TryParse<PropertyType>(value, out var propertyType))
            builder = builder.And(b => b.Type.Equals(propertyType));

        var predicate = builder.Compile();
        
        // Получение данных
        var properties = propertyRepo.GetPropertiesByFilter(predicate).ToList();

        // Сортировка
        var ordered = properties.OrderBy(p => p.Id);
        if (searchParameters.TryGetValue(SearchParameterType.New, out value)
            && bool.TryParse(value, out var isNew))
            ordered = isNew
                ? ordered.OrderByDescending(static p => p.PublicationDate)
                : ordered.OrderBy(p => p.PublicationDate);

        if (searchParameters.TryGetValue(SearchParameterType.HighRated, out value)
            && bool.TryParse(value, out var isHighRated))
            ordered = isHighRated
                ? ordered.ThenByDescending(static p => p.Rating)
                : ordered.ThenBy(b => b.Rating);
        
        // Пагинация
        var paginated = ordered.Skip((extraLoadNumber - 1) * amount).Take(amount).ToList();
        
        return Task.FromResult(paginated);
    }
    
    public async Task<List<string>> GetAddressSuggestionAsync(string address)
    {
        var response = await dadataAddressService.SuggestAddress(address);
        var suggestions = response.suggestions.Select(static s => s.value).ToList();
        return suggestions;
    }
}