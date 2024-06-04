using Placely.Domain.Entities;

namespace Placely.WebAPI.Abstractions.Services;

public interface IReservationService
{
    public Task<Reservation> GetByIdAsNoTrackingAsync(long reservationId);
    public Task<Reservation> CreateAsync(Reservation reservation);
    public Task<Reservation> UpdateAsync(Reservation reservation);
    public Task<Reservation> DeleteAsync(long reservationId);
}