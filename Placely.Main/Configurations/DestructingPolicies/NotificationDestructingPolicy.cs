using Placely.Data.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Main.Configurations.DestructingPolicies;

public class NotificationDestructingPolicy : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory,
        out LogEventPropertyValue result)
    {
        if (value is not Notification n)
        {
            result = new StructureValue(Array.Empty<LogEventProperty>());
            return false;
        }

        var structure = new StructureValue(
            new[]
            {
                new LogEventProperty("Id", new ScalarValue(n.Id)),
                new LogEventProperty("ReceiverId", new ScalarValue(n.ReceiverId)),
                new LogEventProperty("Title", new ScalarValue("[hidden]")),
                new LogEventProperty("Content", new ScalarValue("[hidden]")),
                new LogEventProperty("Date", new ScalarValue(n.Date))
            },
            "Notification");

        result = structure;
        return true;
    }
}