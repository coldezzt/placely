using Microsoft.Extensions.Logging;
using Placely.Application.Abstractions.Repositories;
using Placely.Domain.Entities;

namespace Placely.Persistence.Repositories;

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