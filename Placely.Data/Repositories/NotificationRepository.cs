using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class NotificationRepository(ILogger<NotificationRepository> logger, AppDbContext appDbContext) 
    : Repository<Notification>(logger, appDbContext), INotificationRepository
{
    
}