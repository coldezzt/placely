
using Placely.Data.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Main.Policies.DestructingPolicies;

public class PropertyDestructingPolicy : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory,
        out LogEventPropertyValue result)
    {
        if (value is not Property p)
        {
            result = new StructureValue(Array.Empty<LogEventProperty>());
            return false;
        }

        var structure = new StructureValue(
            new[]
            {
                new LogEventProperty("Id", new ScalarValue(p.Id)),
                new LogEventProperty("OwnerId", new ScalarValue(p.OwnerId)),
                new LogEventProperty("Type", new ScalarValue(p.Type.ToString())),
                new LogEventProperty("PriceListId", new ScalarValue(p.PriceListId)),
                new LogEventProperty("PublicationDate", new ScalarValue(p.PublicationDate)),
            },
            "Property");
        result = structure;
        return true;
    }
}