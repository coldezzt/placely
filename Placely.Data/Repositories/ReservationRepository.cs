using Placely.Data.Abstractions.Repositories;
using Placely.Data.Configurations;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class ReservationRepository(ILogger<ReservationRepository> logger, AppDbContext appDbContext) 
    : Repository<Reservation>(logger, appDbContext), IReservationRepository
{
    public Task<List<Reservation>> FindAllByIdTriplet(Reservation reservation)
    {
        var found = appDbContext.Reservations.Where(r =>
            r.TenantId == reservation.TenantId
            && r.LandlordId == reservation.LandlordId
            && r.PropertyId == reservation.PropertyId)
            .ToList();

        return Task.FromResult(found);
    }
}