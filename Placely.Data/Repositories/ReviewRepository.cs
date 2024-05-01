using Microsoft.EntityFrameworkCore;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

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
}