using Microsoft.Extensions.Logging;
using Placely.Application.Abstractions.Repositories;
using Placely.Domain.Abstractions.Services;

namespace Placely.Application.Services;

public class RatingUpdaterService(
    ILogger<RatingUpdaterService> logger,
    IPropertyRepository propertyRepo,
    IReviewRepository reviewRepo) : IRatingUpdaterService
{
    public async Task UpdatePropertyRating()
    {
        logger.Log(LogLevel.Information, "Begin updating rating for all properties.");
        var properties = propertyRepo.GetPropertiesByFilter().ToList();
        foreach (var property in properties)
        {
            var reviews = await reviewRepo.GetReviewsListByIdAsync(property.Id);
            property.Rating = reviews.Sum(static review => review.Rating) / reviews.Count;
            logger.Log(LogLevel.Trace, "Updated rating for {@property}", property);
        }

        await propertyRepo.SaveChangesAsync();
        logger.Log(LogLevel.Information, "Successfully updated rating for all properties.");
    }
}