using Placely.Data.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Main.Policies.DestructingPolicies;

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
                new LogEventProperty("TenantId", new ScalarValue(r.TenantId)),
                new LogEventProperty("LandlordId", new ScalarValue(r.LandlordId)),
                new LogEventProperty("PropertyId", new ScalarValue(r.PropertyId)),
                new LogEventProperty("ReservationStatus", new ScalarValue(r.ReservationStatus.ToString())),
                new LogEventProperty("DeclineReason", new ScalarValue("******")),
                new LogEventProperty("CreationDateTime", new ScalarValue(r.CreationDateTime))
            },
            "Reservation");
        result = structure;
        return true;
    }
}