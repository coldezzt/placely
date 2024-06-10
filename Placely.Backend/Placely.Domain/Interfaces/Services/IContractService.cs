using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface IContractService
{
    Task<Contract> GetByIdAsNoTrackingAsync(long contractId);
    Task<User> UpdateParticipantStatus(long contractId, long askedId);
    Task<Reservation> GetReservationByIdAsync(long reservationId);
    Task<Contract> GenerateAsync(long reservationId);
    Task<byte[]> GetFileBytesByIdAsync(long contractId, string fileName);
    Task<List<string>> GetFileNamesByUserIdsAsync(List<long> userIds);
}