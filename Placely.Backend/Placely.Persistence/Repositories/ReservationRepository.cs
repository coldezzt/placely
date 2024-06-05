using Microsoft.Extensions.Logging;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Entities;

namespace Placely.Persistence.Repositories;

public class ReservationRepository(ILogger<ReservationRepository> logger, AppDbContext appDbContext) 
    : Repository<Reservation>(logger, appDbContext), IReservationRepository
{
    public Task<List<Reservation>> FindAllByIdTriplet(Reservation reservation)
    {
        var found = appDbContext.Reservations.Where(r =>
            r.Participants.OrderBy(p => p.Id).SequenceEqual(reservation.Participants.OrderBy(p => p.Id))
            && r.PropertyId == reservation.PropertyId)
            .ToList();

        return Task.FromResult(found);
    }
}