namespace BL.Entities;

public class PriceList
{
    public long Id { get; set; }
    
    public long PropertyId { get; set; }
    public Property Property { get; set; }

    public ushort PeriodShort { get; set; }
    public ushort PeriodMedium { get; set; }
    public ushort PeriodLong { get; set; }
}