using Placely.Domain.Entities;

namespace Placely.Application.Abstractions.Repositories;

public interface IReservationRepository : IRepository<Reservation>
{
    public Task<List<Reservation>> FindAllByIdTriplet(Reservation reservation);
}