using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class ReviewService(
    IReviewRepository reviewRepo) : IReviewService
{
    public async Task<Review> GetById(long reviewId)
    {
        return await reviewRepo.GetByIdAsync(reviewId);
    }

    
    public async Task<Review> AddAsync(Review review)
    {
        var result = await reviewRepo.AddAsync(review);
        await reviewRepo.SaveChangesAsync();
        return result;
    }

    public async Task<Review> UpdateAsync(Review review)
    {
        var result = await reviewRepo.UpdateAsync(review);
        await reviewRepo.SaveChangesAsync();
        return result;
    }

    public async Task<Review> DeleteAsync(long reviewId)
    {
        var dbReview = await reviewRepo.GetByIdAsync(reviewId);
        var result = await reviewRepo.DeleteAsync(dbReview);
        await reviewRepo.SaveChangesAsync();
        return result;
    }
}