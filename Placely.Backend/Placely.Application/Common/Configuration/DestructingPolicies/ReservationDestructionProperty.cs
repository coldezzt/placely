using Placely.Domain.Entities;
using Serilog.Core;
using Serilog.Events;

namespace Placely.Application.Common.Configuration.DestructingPolicies;

public class ReservationDestructionProperty : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory,
        out LogEventPropertyValue result)
    {
        if (value is not Reservation r)
        {
            result = new StructureValue(Array.Empty<LogEventProperty>());
            return false;
        }

        var structure = new StructureValue(
            new[]
            {
                new LogEventProperty("Id", new ScalarValue(r.Id)),
                new LogEventProperty("Participants", new ScalarValue(r.Participants)),
                new LogEventProperty("PropertyId", new ScalarValue(r.PropertyId)),
                new LogEventProperty("ReservationStatus", new ScalarValue(r.Status.ToString())),
                new LogEventProperty("DeclineReason", new ScalarValue("******")),
                new LogEventProperty("CreationDateTime", new ScalarValue(r.CreationDateTime)),
                new LogEventProperty("GuestsAmount", new ScalarValue(r.GuestsAmount)),
                new LogEventProperty("PaymentAmount", new ScalarValue(r.PaymentAmount)),
                new LogEventProperty("PaymentFrequency", new ScalarValue(r.PaymentFrequency))
            },
            "Reservation");
        result = structure;
        return true;
    }
}