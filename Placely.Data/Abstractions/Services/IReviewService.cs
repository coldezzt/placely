using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface IReviewService
{
    public Task<Review> GetById(long reviewId);
    public Task<Review> AddAsync(Review review);
    public Task<Review> UpdateAsync(Review review);
    public Task<Review> DeleteAsync(long reviewId);
}