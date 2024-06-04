using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface IReviewService
{
    public Task<Review> GetByIdAsNoTrackingAsync(long reviewId);
    public Task<Review> AddAsync(Review review);
    public Task<Review> UpdateAsync(Review review);
    public Task<Review> DeleteAsync(long reviewId);
    public Task<List<Review>> GetReviewsListByIdAsync(long propertyId, int extraLoadNumber);
}