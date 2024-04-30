using Placely.Data.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Main.Policies.DestructingPolicies;

public class TenantDestructingPolicy : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory,
        out LogEventPropertyValue result)
    {
        if (value is not Tenant t)
        {
            result = new StructureValue(Array.Empty<LogEventProperty>());
            return false;
        }

        var structure = new StructureValue(
            new[]
            {
                new LogEventProperty("Id", new ScalarValue(t.Id)),
                new LogEventProperty("UserRole", new ScalarValue(t.UserRole)),
                new LogEventProperty("Email", new ScalarValue(t.Email)),
                new LogEventProperty("IsAdditionalRegistrationRequired", 
                    new ScalarValue(t.IsAdditionalRegistrationRequired)),
                new LogEventProperty("IsTwoFactorEnabled", new ScalarValue(t.IsTwoFactorEnabled))
            },
            "Tenant");
        result = structure;
        return true;
    }
}