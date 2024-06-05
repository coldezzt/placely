using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface IReservationService
{
    public Task<Reservation> GetByIdAsNoTrackingAsync(long reservationId);
    public Task<Reservation> CreateAsync(Reservation reservation);
    public Task<Reservation> UpdateAsync(Reservation reservation);
    public Task<Reservation> DeleteAsync(long reservationId);
}