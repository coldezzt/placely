namespace Placely.Data.Abstractions.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<TEntity> CreateAsync(TEntity entity);
    public Task<TEntity> Update(TEntity entity);
    public Task<TEntity> Delete(TEntity entity);
    public Task<TEntity> GetByIdAsync(long entityId);
}