namespace Placely.Data.Extensions;

public static class DateTimeExtensions
{
    public static bool IsFuture(this DateTime dt) => DateTime.Now < dt;
    public static bool IsPast(this DateTime dt) => DateTime.Now > dt;
}