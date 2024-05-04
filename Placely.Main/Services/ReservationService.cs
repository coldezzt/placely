using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;
using Placely.Data.Models;
using Placely.Main.Exceptions;

namespace Placely.Main.Services;

public class ReservationService(
    ILogger<ReservationService> logger,
    IReservationRepository reservationRepo) : IReservationService
{
    public Task<Reservation> GetByIdAsNoTrackingAsync(long reservationId)
    {
        return reservationRepo.GetByIdAsNoTrackingAsync(reservationId);
    }

    public async Task<Reservation> CreateAsync(Reservation reservation)
    {
        logger.Log(LogLevel.Trace, "Begin creating reservation: {@reservation}", reservation);
        
        // Если пользователь пытается создать резерирование, у которого время "въезда" раньше,
        // чем время окончания последнего резервирования с этим владельцем в этом здании,
        // то выбрасывается исключение.
        var found = await reservationRepo.FindAllByIdTriplet(reservation);
        var latest = found.MaxBy(f => f.EntryDate + f.Duration);
        if (latest is not null && latest.EntryDate + latest.Duration > reservation.EntryDate)
            throw new ReservationServiceException("Время начала нового резервирования раньше, чем время окончания " +
                                                  "последнего резервирования с этим владельцем в этом имуществе.");
        
        var dbReservation = await reservationRepo.AddAsync(reservation);
        await reservationRepo.SaveChangesAsync();
        
        logger.Log(LogLevel.Debug, "Successfully added reservation: {@reservation}", reservation);
        return dbReservation;
    }

    public async Task<Reservation> UpdateAsync(Reservation reservation)
    {
        logger.Log(LogLevel.Trace, "Begin updating reservation: {@reservation}.", reservation);
        var dbReservation = await reservationRepo.GetByIdAsync(reservation.Id);

        if (reservation.ReservationStatus >= ReservationStatus.InProgress)
            throw new ReservationServiceException("Резервирование уже находится в неизменяемом состоянии.");

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
        var dbReservation = await GetByIdAsNoTrackingAsync(reservationId);
        var deletedReservation = await reservationRepo.DeleteAsync(dbReservation);
        return deletedReservation;
    }
}