using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class ReservationRepository(AppDbContext appDbContext) 
    : Repository<Reservation>(appDbContext), IReservationRepository
{
    
}