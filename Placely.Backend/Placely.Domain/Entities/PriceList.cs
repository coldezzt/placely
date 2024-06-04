using Microsoft.EntityFrameworkCore;
using Placely.Domain.Abstractions.Entities;

namespace Placely.Domain.Entities;

[Owned]
public class PriceList : IEntity
{
    public long Id { get; set; }
    public ushort PeriodShort { get; set; }
    public ushort PeriodMedium { get; set; }
    public ushort PeriodLong { get; set; }
}