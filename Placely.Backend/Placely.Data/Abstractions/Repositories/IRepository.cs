namespace Placely.Data.Abstractions.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public Task<TEntity> DeleteAsync(TEntity entity);
    public Task<TEntity> GetByIdAsNoTrackingAsync(long entityId);
    public Task<TEntity> GetByIdAsync(long entityId);

    public Task SaveChangesAsync(); 
}