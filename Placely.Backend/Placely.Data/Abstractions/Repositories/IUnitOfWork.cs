namespace Placely.Data.Abstractions.Repositories;

public interface IUnitOfWork
{
    public Task SaveChangesAsync();
}