using Microsoft.EntityFrameworkCore;
using Placely.Data.Abstractions;

namespace Placely.Data.Entities;

[Owned]
public class PriceList : IEntity
{
    public long Id { get; set; }
    public ushort PeriodShort { get; set; }
    public ushort PeriodMedium { get; set; }
    public ushort PeriodLong { get; set; }
}