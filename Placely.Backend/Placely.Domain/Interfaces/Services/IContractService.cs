using Placely.Domain.Entities;

namespace Placely.Domain.Interfaces.Services;

public interface IContractService
{
    public Task<Contract> GetByIdAsNoTrackingAsync(long contractId);
    public Task<Reservation> GetReservationByIdAsync(long reservationId);
    public Task<Contract> GenerateAsync(long reservationId);
    public Task<byte[]> GetFileBytesByIdAsync(long contractId, string fileName);
    public Task<List<string>> GetFileNamesByUserIdsAsync(List<long> userIds);
}