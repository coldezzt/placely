using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface IReservationService
{
    Task<Reservation> GetByIdAsNoTrackingAsync(long reservationId);
    Task<Reservation> CreateAsync(Reservation reservation);
    Task<Reservation> UpdateAsync(Reservation reservation);
    Task<Reservation> DeleteAsync(long reservationId);
}