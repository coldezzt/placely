using Placely.Data.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Main.Configurations.DestructingPolicies;

public class ChatDestructingPolicy : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory,
        out LogEventPropertyValue result)
    {
        if (value is Chat c)
        {
            var structure = new StructureValue(new[]
            {
                new LogEventProperty("Id", new ScalarValue(c.Id)),
                new LogEventProperty("FirstUserId", new ScalarValue(c.FirstUserId)),
                new LogEventProperty("SecondUserId", new ScalarValue(c.SecondUserId))
            }, "Chat");

            result = structure;
            return true;
        }

        result = new StructureValue(Array.Empty<LogEventProperty>());
        return false;
    }
}