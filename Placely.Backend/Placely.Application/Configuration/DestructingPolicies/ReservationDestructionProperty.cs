using Placely.Domain.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Application.Configuration.DestructingPolicies;

public class ReservationDestructionProperty : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory,
        out LogEventPropertyValue result)
    {
        if (value is not Reservation r)
        {
            result = new StructureValue(Array.Empty<LogEventProperty>());
            return false;
        }

        var structure = new StructureValue(
            new[]
            {
                new LogEventProperty("Id", new ScalarValue(r.Id)),
                new LogEventProperty("TenantId", new ScalarValue(r.TenantId)),
                new LogEventProperty("LandlordId", new ScalarValue(r.LandlordId)),
                new LogEventProperty("PropertyId", new ScalarValue(r.PropertyId)),
                new LogEventProperty("ReservationStatus", new ScalarValue(r.StatusType.ToString())),
                new LogEventProperty("DeclineReason", new ScalarValue("******")),
                new LogEventProperty("CreationDateTime", new ScalarValue(r.CreationDateTime))
            },
            "Reservation");
        result = structure;
        return true;
    }
}