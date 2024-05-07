using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Repositories;

public interface IReservationRepository : IRepository<Reservation>
{
    public Task<List<Reservation>> FindAllByIdTriplet(Reservation reservation);
}