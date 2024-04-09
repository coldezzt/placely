using Placely.Data.Abstractions.Repositories;
using Placely.Data.Abstractions.Services;
using Placely.Data.Entities;

namespace Placely.Main.Services;

public class ContractService(
    IReservationRepository reservationRepository,
    IContractRepository contractRepository,
    IUnitOfWork unitOfWork) : IContractService
{
    public async Task<Contract> GenerateContractAsync(long reservationId)
    {
        var reservation = reservationRepository.GetByIdAsync(reservationId);
        
        return new Contract();
    }
}