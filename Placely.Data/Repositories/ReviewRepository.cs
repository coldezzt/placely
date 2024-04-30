using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class ReviewRepository(ILogger logger, AppDbContext appDbContext) 
    : Repository<Review>(logger, appDbContext), IReviewRepository
{
}