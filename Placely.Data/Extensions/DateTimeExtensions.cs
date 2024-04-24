namespace Placely.Data.Extensions;

public static class DateTimeExtensions
{
    public static bool IsFuture(this DateTime dt) => DateTime.UtcNow < dt;
    public static bool IsPast(this DateTime dt) => DateTime.UtcNow > dt;
}