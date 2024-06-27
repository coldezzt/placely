using Microsoft.EntityFrameworkCore;
using Placely.Domain.Interfaces.Entities;

namespace Placely.Domain.Entities;

public class PriceList : IEntity
{
    public long Id { get; set; }
    
    public required decimal PeriodShort { get; set; }
    public required decimal PeriodMedium { get; set; }
    public required decimal PeriodLong { get; set; }
    
    public virtual Property Property { get; set; }
}