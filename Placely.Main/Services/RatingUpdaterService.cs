using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;

namespace Placely.Main.Services;

public class RatingUpdaterService(
    ILogger<RatingUpdaterService> logger,
    IPropertyRepository propertyRepo) : IRatingUpdaterService
{
    public async Task UpdatePropertyRating()
    {
        logger.Log(LogLevel.Information, "Begin updating rating for all properties.");
        var properties = propertyRepo.GetPropertiesByFilter().ToList();
        foreach (var property in properties)
        {
            var reviews = await propertyRepo.GetReviewsListByIdAsync(property.Id);
            property.Rating = reviews.Sum(static review => review.Rating) / reviews.Count;
            logger.Log(LogLevel.Trace, "Updated rating for {@property}", property);
        }

        await propertyRepo.SaveChangesAsync();
        logger.Log(LogLevel.Information, "Successfully updated rating for all properties.");
    }
}