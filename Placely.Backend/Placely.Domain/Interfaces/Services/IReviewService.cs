using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface IReviewService
{
    Task<Review> GetByIdAsNoTrackingAsync(long reviewId);
    Task<Review> AddAsync(Review review);
    Task<Review> UpdateAsync(Review review);
    Task<Review> DeleteAsync(long reviewId);
    Task<List<Review>> GetReviewsListByIdAsync(long propertyId, int extraLoadNumber);
}