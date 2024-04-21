using LinqKit;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;
using Placely.Data.Models;

namespace Placely.Main.Services;

public class PropertyService(IPropertyRepository propertyRepo) 
    : IPropertyService
{
    public async Task<Property> GetByIdAsync(long propertyId)
    {
        return await propertyRepo.GetByIdAsync(propertyId);
    }
    
    public async Task<Property> AddAsync(Property property)
    {
        var dbEntity = await propertyRepo.AddAsync(property);
        await propertyRepo.SaveChangesAsync();
        return dbEntity;
    }

    public async Task<Property> UpdateAsync(Property property)
    {
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
                ? properties.OrderByDescending(p => p.PublicationDate)
                : properties.OrderBy(p => p.PublicationDate);

        if (searchParameters.TryGetValue(SearchParameter.HighRated, out value)
            && bool.TryParse(value, out var isHighRated))
            ordered = isHighRated
                ? ordered.ThenByDescending(p => p.Rating)
                : ordered.ThenBy(b => b.Rating);
        
        // Пагинация
        var paginated = ordered.Skip((extraLoadNumber - 1) * amount).Take(amount);
        
        return Task.FromResult(paginated.ToList());
    }
}