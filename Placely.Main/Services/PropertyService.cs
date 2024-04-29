using LinqKit;
using Microsoft.EntityFrameworkCore;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;
using Placely.Data.Models;
using Placely.Main.Exceptions;

namespace Placely.Main.Services;

public class PropertyService(
    IPropertyRepository propertyRepo,
    IDadataAddressService dadataAddressService) : IPropertyService
{
    public async Task<Property> GetByIdAsync(long propertyId)
    {
        return await propertyRepo.GetByIdAsync(propertyId);
    }
    
    public async Task<Property> AddAsync(Property property)
    {
        var address = property.Address;
        var parsedAddress = await dadataAddressService.NormalizeAddressAsync(address);
        if (parsedAddress.unparsed_parts != null)
            throw new AddressException("Адрес содержит части, которые не могут быть нормализованы.");
        
        var dbEntity = await propertyRepo.AddAsync(property);
        await propertyRepo.SaveChangesAsync();
        return dbEntity;
    }

    public async Task<Property> UpdateAsync(Property property)
    {
        var address = property.Address;
        var parsedAddress = await dadataAddressService.NormalizeAddressAsync(address);
        if (parsedAddress.unparsed_parts != null)
            throw new AddressException("Адрес содержит части, которые не могут быть нормализованы.");
        
        var dbEntity = await propertyRepo.UpdateAsync(property);
        await propertyRepo.SaveChangesAsync();
        return dbEntity;
    }

    public async Task<Property> DeleteAsync(long propertyId)
    {
        var property = await propertyRepo.GetByIdAsync(propertyId);
        var dbEntity = await propertyRepo.DeleteAsync(property);
        await propertyRepo.SaveChangesAsync();
        return dbEntity;
    }

    public Task<List<Property>> GetChunkByFilterAsync(
        Dictionary<SearchParameter, string> searchParameters,
        int extraLoadNumber,
        int amount)
    {
        // Сборка предиката
        var builder = PredicateBuilder.New<Property>();

        if (searchParameters.TryGetValue(SearchParameter.Category, out var value)
            && Enum.TryParse<PropertyType>(value, out var propertyType))
            builder = builder.And(b => b.Type.Equals(propertyType));

        var predicate = builder.Compile();
        
        // Получение данных
        var properties = propertyRepo.GetPropertiesByFilter(predicate);

        // Сортировка
        var ordered = (IOrderedQueryable<Property>) properties;
        if (searchParameters.TryGetValue(SearchParameter.New, out value)
            && bool.TryParse(value, out var isNew))
            ordered = isNew
                ? properties.OrderByDescending(static p => p.PublicationDate)
                : properties.OrderBy(static p => p.PublicationDate);

        if (searchParameters.TryGetValue(SearchParameter.HighRated, out value)
            && bool.TryParse(value, out var isHighRated))
            ordered = isHighRated
                ? ordered.ThenByDescending(static p => p.Rating)
                : ordered.ThenBy(static b => b.Rating);
        
        // Пагинация
        var paginated = ordered.Skip((extraLoadNumber - 1) * amount).Take(amount).ToListAsync();
        
        return paginated;
    }
    
    public async Task<List<Review>> GetListByPropertyIdAsync(long propertyId, int extraLoadNumber = 0)
    {
        var reviews = await propertyRepo.GetListByPropertyIdAsync(propertyId);
        return reviews
            .OrderByDescending(static r => r.Date)
            .Skip((extraLoadNumber - 1) * 10)
            .Take(10)
            .ToList();
    }

    public async Task<List<string>> GetAddressSuggestionAsync(string address)
    {
        var response = await dadataAddressService.SuggestAddress(address);
        var suggestions = response.suggestions.Select(static s => s.value).ToList();
        return suggestions;
    }
}