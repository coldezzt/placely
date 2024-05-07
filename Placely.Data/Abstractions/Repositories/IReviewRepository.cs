using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Repositories;

public interface IReviewRepository : IRepository<Review>
{
    public Task<Review?> TryFindByAuthorIdAndPropertyId(long authorId, long propertyId);
    public Task<List<Review>> GetReviewsListByIdAsync(long propertyId);
}