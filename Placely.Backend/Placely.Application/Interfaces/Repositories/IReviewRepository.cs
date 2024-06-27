using Placely.Domain.Entities;

namespace Placely.Application.Interfaces.Repositories;

public interface IReviewRepository : IRepository<Review>
{
    Task<Review?> TryFindByAuthorIdAndPropertyId(long authorId, long propertyId);
    Task<List<Review>> GetReviewsListByIdAsync(long propertyId);
}