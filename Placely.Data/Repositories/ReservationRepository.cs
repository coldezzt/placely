using Placely.Data.Abstractions.Repositories;
using Placely.Data.Entities;

namespace Placely.Data.Repositories;

public class ReservationRepository : IReservationRepository
{
    public Task<Reservation> CreateAsync(Reservation entity)
    {
        throw new NotImplementedException();
    }

    public Reservation Update(Reservation entity)
    {
        throw new NotImplementedException();
    }

    public Reservation Delete(Reservation entity)
    {
        throw new NotImplementedException();
    }

    public Task<Reservation?> GetByIdAsync(long entityId)
    {
        throw new NotImplementedException();
    }
}