using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Entities;

namespace Placely.Persistence.Repositories;

public class ReviewRepository(ILogger<ReviewRepository> logger, AppDbContext appDbContext) 
    : Repository<Review>(logger, appDbContext), IReviewRepository
{
    public async Task<Review?> TryFindByAuthorIdAndPropertyId(long authorId, long propertyId)
    {
        logger.Log(LogLevel.Trace, "Begin getting review by author and property: " +
                                   "{authorId} and {propertyId}.", authorId, propertyId);
        var found = await appDbContext.Reviews.FirstOrDefaultAsync(r =>
            r.AuthorId == authorId && r.PropertyId == propertyId);
        
        logger.Log(LogLevel.Information, "By this author and property: {authorId} and {propertyId}, " +
                                         "Found: {@review}", authorId, propertyId, found);
        return found;
    }
    
    public async Task<List<Review>> GetReviewsListByIdAsync(long propertyId)
    {
        logger.Log(LogLevel.Debug, $"Begin getting reviews list of property with Id: {propertyId}");
        
        var reviews = await appDbContext.Reviews.Where(r => r.PropertyId == propertyId).ToListAsync();
        
        logger.Log(LogLevel.Debug, $"Successfully got reviews list of property with Id: {propertyId}");
        return reviews;
    }
}