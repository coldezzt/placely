using Microsoft.Extensions.Logging;
using Placely.Application.Common.Exceptions;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Common.Enums;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;

namespace Placely.Application.Services;

public class ReservationService(
    ILogger<ReservationService> logger,
    IReservationRepository reservationRepo) : IReservationService
{
    public Task<Reservation> GetByIdAsNoTrackingAsync(long reservationId)
    {
        return reservationRepo.GetByIdAsNoTrackingAsync(reservationId);
    }

    public async Task<User> UpdateReservationStatus(long contractId, long askedId)
    {
        var dbReservation = await reservationRepo.GetByIdAsync(contractId);
        var asked = dbReservation.Participants.First(p => p.Id == askedId);
        if (asked.UserRole == UserRoleType.Landlord)
            dbReservation.StatusType = ReservationStatusType.InProgress;

        await reservationRepo.SaveChangesAsync();
        return asked;
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

        if (reservation.StatusType >= ReservationStatusType.InProgress)
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