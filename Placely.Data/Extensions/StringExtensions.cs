namespace Placely.Data.Extensions;

public static class StringExtensions
{
    public static bool ContainsOnlyLettersAndPunctuation(this string s) =>
        s.Any(c => char.IsLetter(c) || char.IsPunctuation(c));
}