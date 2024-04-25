using System.Text.RegularExpressions;

namespace Placely.Data.Dtos.Validators;

public static class ValidatorMethods
{
    private static readonly Regex EmailPattern = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    private static readonly Regex PasswordPattern = new(@"^[a-zA-Z0-9._%+-=;:!?]");
    private static readonly Regex PhoneNumberPattern = new(@"^((\+7|7|8)+([0-9]){10})$");

    public static bool IsEmail(string str) => EmailPattern.IsMatch(str);
    public static bool IsPassword(string str) => PasswordPattern.IsMatch(str);
    public static bool IsPhoneNumber(string str) => PhoneNumberPattern.IsMatch(str);
    public static bool IsFuture(DateTime dt) => DateTime.UtcNow < dt;
}