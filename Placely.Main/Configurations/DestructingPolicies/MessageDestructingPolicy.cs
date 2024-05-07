using Placely.Data.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Main.Configurations.DestructingPolicies;

public class MessageDestructingPolicy : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory,
        out LogEventPropertyValue result)
    {
        if (value is not Message m)
        {
            result = new StructureValue(Array.Empty<LogEventProperty>());
            return false;
        }

        var structure = new StructureValue(
            new[]
            {
                new LogEventProperty("Id", new ScalarValue(m.Id)),
                new LogEventProperty("ChatId", new ScalarValue(m.ChatId)),
                new LogEventProperty("AuthorId", new ScalarValue(m.AuthorId)),
                new LogEventProperty("Content", new ScalarValue("[hidden]")),
                new LogEventProperty("Date", new ScalarValue(m.Date))
            }, 
            "Message");

        result = structure;
        return true;
    }
}