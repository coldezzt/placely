using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Abstractions.Services;

public interface IContractService
{
    public Task<Contract> GetByIdAsNoTrackingAsync(long contractId);
    public Task<Reservation> GetReservationByIdAsync(long reservationId);
    public Task<Contract> GenerateAsync(ContractCreationDto dto);
    public Task<byte[]> GetFileBytesByIdAsync(long contractId, string fileName);
    public Task<List<string>> GetFileNamesListByLandlordAndTenantIdAsync(long landlordId, long tenantId);
}