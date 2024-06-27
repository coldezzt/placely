namespace Placely.Application.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
    Task<TEntity> GetByIdAsNoTrackingAsync(long entityId);
    Task<TEntity> GetByIdAsync(long entityId);

    Task SaveChangesAsync(); 
}