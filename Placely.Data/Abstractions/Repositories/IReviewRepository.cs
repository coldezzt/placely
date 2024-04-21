using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Repositories;

public interface IReviewRepository : IRepository<Review>
{
    public Task<List<Review>> GetListByPropertyIdAsync(long propertyId);
}