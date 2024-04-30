using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class ReservationRepository(ILogger<ReservationRepository> logger, AppDbContext appDbContext) 
    : Repository<Reservation>(logger, appDbContext), IReservationRepository
{
    
}