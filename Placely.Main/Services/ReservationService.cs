using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class ReservationService(
    ILogger<ReservationService> logger,
    IReservationRepository reservationRepo) : IReservationService
{
    public Task<Reservation> GetByIdAsync(long reservationId)
    {
        return reservationRepo.GetByIdAsync(reservationId);
    }

    public async Task<Reservation> CreateAsync(Reservation reservation)
    {
        return await reservationRepo.AddAsync(reservation);
    }

    public async Task<Reservation> UpdateAsync(Reservation reservation)
    {
        logger.Log(LogLevel.Trace, "Begin updating reservation: {@reservation}.", reservation);
        var dbReservation = await reservationRepo.GetByIdAsync(reservation.Id);

        dbReservation.Duration = reservation.Duration;
        dbReservation.EntryDate = reservation.EntryDate;
        dbReservation.GuestsAmount = reservation.GuestsAmount;
        logger.Log(LogLevel.Trace, "Updated values in reservation: {@reservation}.", reservation);
        
        await reservationRepo.UpdateAsync(dbReservation);
        await reservationRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Information, "Successfully updated reservation: {@reservation}.", reservation);
        return dbReservation;
    }

    public async Task<Reservation> DeleteAsync(long reservationId)
    {
        var dbReservation = await GetByIdAsync(reservationId);
        var deletedReservation = await reservationRepo.DeleteAsync(dbReservation);
        return deletedReservation;
    }
}