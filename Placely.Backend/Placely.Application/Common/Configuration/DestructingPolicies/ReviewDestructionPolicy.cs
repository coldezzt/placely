using Placely.Domain.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Application.Common.Configuration.DestructingPolicies;

public class ReviewDestructionPolicy : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory,
        out LogEventPropertyValue result)
    {
        if (value is not Review r)
        {
            result = new StructureValue(Array.Empty<LogEventProperty>());
            return false;
        }

        var structure = new StructureValue(
            new[]
            {
                new LogEventProperty("Id", new ScalarValue(r.Id)),
                new LogEventProperty("AuthorId", new ScalarValue(r.AuthorId)),
                new LogEventProperty("PropertyId", new ScalarValue(r.PropertyId)),
                new LogEventProperty("Rating", new ScalarValue(r.Rating)),
                new LogEventProperty("Date", new ScalarValue(r.Date))
            },
            "Review");
        result = structure;
        return true;
    }
}