using Placely.Data.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Main.Policies.DestructingPolicies;

public class PreviousPasswordDestructingPolicy : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory,
        out LogEventPropertyValue result)
    {
        if (value is not PreviousPassword pp)
        {
            result = new StructureValue(Array.Empty<LogEventProperty>());
            return false;
        }

        var structure = new StructureValue(
            new[]
            {
                new LogEventProperty("TenantId", new ScalarValue(pp.TenantId)),
                new LogEventProperty("Password", new ScalarValue("[hidden]"))
            },
            "PreviousPassword");
        result = structure;
        return true;
    }
}