using Placely.Data.Dtos.Requests;
using Placely.Data.Entities;

namespace Placely.Data.Abstractions.Services;

public interface IContractService
{
    public Task<Contract> GetContractByIdAsync(long id);
    public Task<Reservation> GetReservationByIdAsync(long reservationId);
    public Task<Contract> GenerateContractAsync(ContractCreateRequestDto dto);
}