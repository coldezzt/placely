using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class ReviewService : IReviewService
{
    public Task<Review> AddAsync(long propertyId, Review review)
    {
        throw new NotImplementedException();
    }
}