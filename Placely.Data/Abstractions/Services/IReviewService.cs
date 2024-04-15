using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface IReviewService
{
    public Task<Review> AddAsync(long propertyId, Review review);
}