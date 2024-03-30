using Placely.Data.Abstractions.Repositories;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class ReviewRepository : IReviewRepository
{
    public Task<Review> CreateAsync(Review entity)
    {
        throw new NotImplementedException();
    }

    public Review Update(Review entity)
    {
        throw new NotImplementedException();
    }

    public Review Delete(Review entity)
    {
        throw new NotImplementedException();
    }

    public Task<Review?> GetByIdAsync(long entityId)
    {
        throw new NotImplementedException();
    }
}