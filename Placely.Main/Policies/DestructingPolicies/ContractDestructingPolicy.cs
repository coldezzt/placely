using Placely.Data.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Main.Extensions;

public class ContractDestructingPolicy : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory,
        out LogEventPropertyValue result)
    {
        if (value is not Contract c)
        {
            result = new StructureValue(Array.Empty<LogEventProperty>());
            return false;
        }

        var structure = new StructureValue(
            new[]
            {
                new LogEventProperty("TenantId", new ScalarValue(c.TenantId)),
                new LogEventProperty("LandlordId", new ScalarValue(c.LandlordId)),
                new LogEventProperty("PropertyId", new ScalarValue(c.PropertyId)),
                new LogEventProperty("LeaseStartDateTime", new ScalarValue(c.LeaseStartDateTime)),
                new LogEventProperty("LeaseEndDateTime", new ScalarValue(c.LeaseEndDateTime))
            },
            "Contract");

        result = structure;
        return true;
    }
}