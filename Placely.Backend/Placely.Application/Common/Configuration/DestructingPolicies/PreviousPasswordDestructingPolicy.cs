using Placely.Domain.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Application.Common.Configuration.DestructingPolicies;

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
                new LogEventProperty("Id", new ScalarValue(pp.Id)),
                new LogEventProperty("TenantId", new ScalarValue(pp.UserId)),
                new LogEventProperty("Password", new ScalarValue("[hidden]"))
            },
            "PreviousPassword");
        result = structure;
        return true;
    }
}