using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface IRegistrationService
{
    public Task<User> RegisterUserAsync(User user);

    public Task<User> FinalizeUserAsync(User user);
}