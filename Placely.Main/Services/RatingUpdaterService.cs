using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;

namespace Placely.Main.Services;

public class RatingUpdaterService(
    IPropertyRepository propertyRepo) : IRatingUpdaterService
{
    public async Task UpdatePropertyRating()
    {
        var properties = propertyRepo.GetPropertiesByFilter().ToList();
        foreach (var property in properties)
        {
            var reviews = await propertyRepo.GetListByPropertyIdAsync(property.Id);
            property.Rating = reviews.Sum(static review => review.Rating) / reviews.Count;
        }

        await propertyRepo.SaveChangesAsync();
    }
}