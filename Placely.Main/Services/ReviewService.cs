using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;
using Placely.Data.Exceptions;

namespace Placely.Main.Services;

public class ReviewService(
    ILogger<ReviewService> logger,
    IReviewRepository reviewRepo) 
    : IReviewService
{
    public async Task<Review> GetByIdAsNoTrackingAsync(long reviewId)
    {
        return await reviewRepo.GetByIdAsNoTrackingAsync(reviewId);
    }
    
    public async Task<Review> AddAsync(Review review)
    {
        var found = await reviewRepo.TryFindByAuthorIdAndPropertyId(review.AuthorId, review.PropertyId);
        if (found is not null)
            throw new ConflictException("Пользователь уже оставлял отзыв на это имущество!");
        
        var result = await reviewRepo.AddAsync(review);
        await reviewRepo.SaveChangesAsync();
        return result;
    }

    public async Task<Review> UpdateAsync(Review review)
    {
        var dbReview = await reviewRepo.GetByIdAsNoTrackingAsync(review.Id);
        dbReview.Content = review.Content;
        dbReview.Rating = review.Rating;
        
        var updatedReview = await reviewRepo.UpdateAsync(dbReview);
        await reviewRepo.SaveChangesAsync();
        return updatedReview;
    }

    public async Task<Review> DeleteAsync(long reviewId)
    {
        var dbReview = await reviewRepo.GetByIdAsNoTrackingAsync(reviewId);
        var result = await reviewRepo.DeleteAsync(dbReview);
        await reviewRepo.SaveChangesAsync();
        return result;
    }
    
    public async Task<List<Review>> GetReviewsListByIdAsync(long propertyId, int extraLoadNumber = 0)
    {
        logger.Log(LogLevel.Trace, "Begin getting review list of property with id: {propertyId}", propertyId);

        var reviews = await reviewRepo.GetReviewsListByIdAsync(propertyId);
        var result = reviews
            .OrderByDescending(static r => r.Date)
            .Skip((extraLoadNumber - 1) * 10)
            .Take(10)
            .ToList();

        logger.Log(LogLevel.Information, "Successfully got review list of property with id: {propertyId}", propertyId);
        return result;
    }

}