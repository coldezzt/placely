using Microsoft.EntityFrameworkCore;
using Placely.Data.Abstractions;
using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Exceptions;

namespace Placely.Data.Repositories;

public abstract class Repository<TEntity>(ILogger logger, AppDbContext appDbContext)
    : IRepository<TEntity> where TEntity : class, IEntity
{
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        logger.Log(LogLevel.Information, "Begin adding an entity: {@entity}.", entity);
        var result = await appDbContext.Set<TEntity>().AddAsync(entity);
        logger.Log(LogLevel.Information, "Successfully added: {@entity}.", entity);
        return result.Entity;
    }

    public virtual Task<TEntity> UpdateAsync(TEntity entity)
    {
        logger.Log(LogLevel.Information, "Begin updating an entity: {@entity}.", entity);

        var set = appDbContext.Set<TEntity>();
        var found = set.FirstOrDefault(e => e.Id == entity.Id);
        if (found is null)
            throw new EntityNotFoundException(typeof(TEntity), entity.Id.ToString());
        
        var result = set.Update(entity);
        logger.Log(LogLevel.Information, "Successfully updated: {@entity}.", entity);
        return Task.FromResult(result.Entity);
    }

    public virtual Task<TEntity> DeleteAsync(TEntity entity)
    {
        logger.Log(LogLevel.Information, "Begin deleting an entity: {@entity}.", entity);

        var set = appDbContext.Set<TEntity>();
        var found = set.FirstOrDefault(e => e.Id == entity.Id);
        if (found is null)
            throw new EntityNotFoundException(typeof(TEntity), entity.Id.ToString());
        
        var result = set.Remove(entity);
        logger.Log(LogLevel.Information, "Successfully deleted: {@entity}.", entity);
        return Task.FromResult(result.Entity);
    }

    public virtual async Task<TEntity> GetByIdAsync(long entityId)
    {
        logger.Log(LogLevel.Debug, "Begin getting an entity: {@1} with Id = {@2}.", typeof(TEntity).Name, entityId);
        
        var set = appDbContext.Set<TEntity>();
        var result = await set.FirstOrDefaultAsync(e => e.Id == entityId);
        if (result is null)
            throw new EntityNotFoundException(typeof(TEntity), entityId.ToString());
        
        logger.Log(LogLevel.Debug, "Successfully got: {@1} with Id = {@2}.", typeof(TEntity).Name, entityId);
        return result;
    }

    public virtual async Task SaveChangesAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}