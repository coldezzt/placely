using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface IRegistrationService
{
    Task<User> RegisterUserAsync(User user);

    Task<User> FinalizeUserAsync(User user);
}