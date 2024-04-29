using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class ReservationService(
    IReservationRepository reservationRepo) : IReservationService
{
    public async Task<Reservation> GetByIdAsync(long reservationId)
    {
        var result = await reservationRepo.GetByIdAsync(reservationId);
        return result;
    }

    public async Task<Reservation> CreateAsync(Reservation reservation)
    {
        var result = await reservationRepo.AddAsync(reservation);
        return result;
    }

    public async Task<Reservation> UpdateAsync(Reservation reservation)
    {
        var dbReservation = await reservationRepo.GetByIdAsync(reservation.Id);

        dbReservation.Duration = reservation.Duration;
        dbReservation.EntryDate = reservation.EntryDate;
        dbReservation.GuestsAmount = reservation.GuestsAmount;

        await reservationRepo.UpdateAsync(dbReservation);
        await reservationRepo.SaveChangesAsync();
        return dbReservation;
    }

    public async Task<Reservation> DeleteAsync(long reservationId)
    {
        var dbReservation = await GetByIdAsync(reservationId);
        var deletedReservation = await reservationRepo.DeleteAsync(dbReservation);
        return deletedReservation;
    }
}