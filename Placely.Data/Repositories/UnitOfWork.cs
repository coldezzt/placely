using Placely.Data.Configurations;

namespace Placely.Data.Repositories;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}