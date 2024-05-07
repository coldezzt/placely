namespace Placely.Data.Dtos.Validators;

public static class ValidatorErrorMessages
{
    public static string NullOrEmpty() => "Поле не может быть пусто";

    public static string StringLengthShouldBeLessThan(int value) => $"Количество символов должно быть меньше чем {value}";

    public static string StringLengthShouldBeBiggerThan(int value) => $"Количество символов должно быть больше чем {value}";

    public static string StringContainOnly(string possibleValues) => $"Поле должно содержать только: {possibleValues}";

    public static string StringImpossibleValue(string possibleValues) => $"Поле может быть равно только: {possibleValues}";

    public static string StringUnparsableValue() => "Невозможное значение поля";

    public static string StringWrongFormat() => "Неверный формат поля";

    public static string DateTimeShouldBeNotFromFuture() => "Дата не может быть в будущем";
    public static string DateTimeShouldBeNotFromPast() => "Дата не может быть в прошлом";
    public static string TimeSpanDurationShouldBeMoreThan(int value) => $"Интервал должен быть длиннее чем {value}";
}