namespace Placely.Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    public Task SaveChangesAsync();
}