namespace Placely.Data.Entities;

public class PriceList
{
    public long Id { get; set; }
    public ushort PeriodShort { get; set; }
    public ushort PeriodMedium { get; set; }
    public ushort PeriodLong { get; set; }
}