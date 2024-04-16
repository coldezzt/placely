using Microsoft.EntityFrameworkCore;
using Placely.Data.Abstractions;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Exceptions;

namespace Placely.Data.Repositories;

public abstract class Repository<TEntity>(AppDbContext appDbContext)
    : IRepository<TEntity> where TEntity : class, IEntity
{
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        var result = await appDbContext.Set<TEntity>().AddAsync(entity);
        return result.Entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var set = appDbContext.Set<TEntity>();
        if (await set.FindAsync(entity) is null)
            throw new EntityNotFoundException(typeof(TEntity), entity.Id.ToString());
        
        var result = set.Update(entity);
        return result.Entity;
    }

    public virtual async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var set = appDbContext.Set<TEntity>();
        if (await set.FindAsync(entity) is null)
            throw new EntityNotFoundException(typeof(TEntity), entity.Id.ToString());
        
        var result = set.Remove(entity);
        return result.Entity;
    }

    public virtual async Task<TEntity> GetByIdAsync(long entityId)
    {
        var set = appDbContext.Set<TEntity>();
        var result = await set.FirstOrDefaultAsync(e => e.Id == entityId);
        if (result is null)
            throw new EntityNotFoundException(typeof(TEntity), entityId.ToString());
        
        return result;
    }

    public virtual async Task SaveChangesAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}