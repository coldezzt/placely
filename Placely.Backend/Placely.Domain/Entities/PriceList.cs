using Microsoft.EntityFrameworkCore;
using Placely.Domain.Interfaces.Entities;

namespace Placely.Domain.Entities;

[Owned]
public class PriceList : IEntity
{
    public long Id { get; set; }

    public long PropertyId { get; set; }
    public virtual Property Property { get; set; }
    
    public decimal PeriodShort { get; set; }
    public decimal PeriodMedium { get; set; }
    public decimal PeriodLong { get; set; }
}