using LinqKit.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Placely.Application.Interfaces.Repositories;
using Placely.Domain.Entities;

namespace Placely.Persistence.Repositories;

public class ReservationRepository(ILogger<ReservationRepository> logger, AppDbContext appDbContext) 
    : Repository<Reservation>(logger, appDbContext), IReservationRepository
{
    // Используется для получения всех резервирований и контрактов
    // между арнедатором и арендодателем в конкретном имуществе
    public Task<List<Reservation>> FindAllByIdTriplet(long tenantId, long landlordId, long propertyId)
    {
        var found = appDbContext.Reservations.FromSql(
            $"""
            select * from reservations_by_tenant_landlord_property_ids
                (tenantId := {tenantId}, landlordId := {landlordId}, propertyId := {propertyId});
            """).ToList();
        
        return Task.FromResult(found);
    }
}