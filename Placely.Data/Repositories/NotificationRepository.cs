using Placely.Data.Abstractions.Repositories;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class NotificationRepository : INotificationRepository
{
    public Task<Notification> CreateAsync(Notification entity)
    {
        throw new NotImplementedException();
    }

    public Notification Update(Notification entity)
    {
        throw new NotImplementedException();
    }

    public Notification Delete(Notification entity)
    {
        throw new NotImplementedException();
    }

    public Task<Notification?> GetByIdAsync(long entityId)
    {
        throw new NotImplementedException();
    }
}