namespace Placely.Application.Abstractions.Repositories;

public interface IUnitOfWork
{
    public Task SaveChangesAsync();
}