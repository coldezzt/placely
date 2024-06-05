using Placely.Domain.Entities;

namespace Placely.Application.Interfaces.Repositories;

public interface IReviewRepository : IRepository<Review>
{
    public Task<Review?> TryFindByAuthorIdAndPropertyId(long authorId, long propertyId);
    public Task<List<Review>> GetReviewsListByIdAsync(long propertyId);
}