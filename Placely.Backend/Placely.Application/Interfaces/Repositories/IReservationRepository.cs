using Placely.Domain.Entities;

namespace Placely.Application.Interfaces.Repositories;

public interface IReservationRepository : IRepository<Reservation>
{
    Task<List<Reservation>> FindAllByIdTriplet(Reservation reservation);
}