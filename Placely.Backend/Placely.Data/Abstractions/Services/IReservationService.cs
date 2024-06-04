using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface IReservationService
{
    public Task<Reservation> GetByIdAsNoTrackingAsync(long reservationId);
    public Task<Reservation> CreateAsync(Reservation reservation);
    public Task<Reservation> UpdateAsync(Reservation reservation);
    public Task<Reservation> DeleteAsync(long reservationId);
}