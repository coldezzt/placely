using Microsoft.Extensions.Logging;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Entities;

namespace Placely.Persistence.Repositories;

public class NotificationRepository(ILogger<NotificationRepository> logger, AppDbContext appDbContext) 
    : Repository<Notification>(logger, appDbContext), INotificationRepository
{
    
}