using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface IContractService
{
    public Task<Contract> GetByIdAsNoTrackingAsync(long contractId);
    public Task<Reservation> GetReservationByIdAsync(long reservationId);
    public Task<Contract> GenerateAsync(ContractCreationDto dto);
    public Task<byte[]> GetFileBytesByIdAsync(long contractId, string format = "pdf");
    public Task<List<string>> GetFileNamesListByLandlordIdAsync(long landlordId);

}