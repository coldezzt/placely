using Placely.Domain.Entities;

namespace Placely.Domain.Abstractions.Services;

public interface IContractService
{
    public Task<Contract> GetByIdAsNoTrackingAsync(long contractId);
    public Task<Reservation> GetReservationByIdAsync(long reservationId);
    public Task<Contract> GenerateAsync(long reservationId); // нужно придумать как убрать дто,
                                                          // пока идея в том чтобы принимать на вход Reservation
    public Task<byte[]> GetFileBytesByIdAsync(long contractId, string fileName);
    public Task<List<string>> GetFileNamesListByLandlordAndTenantIdAsync(long landlordId, long tenantId);
}