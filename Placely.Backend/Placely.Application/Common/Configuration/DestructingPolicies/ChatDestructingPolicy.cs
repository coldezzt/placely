using Placely.Domain.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Application.Common.Configuration.DestructingPolicies;

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
                new LogEventProperty("Participants", new ScalarValue(c.Participants)),
            }, "Chat");

            result = structure;
            return true;
        }

        result = new StructureValue(Array.Empty<LogEventProperty>());
        return false;
    }
}