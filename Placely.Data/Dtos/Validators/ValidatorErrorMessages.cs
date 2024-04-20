namespace Placely.Data.Dtos.Validators;

public static class ValidatorErrorMessages
{
    public static string StringNullOrEmpty() => "Поле не может быть пусто";

    public static string StringLengthShouldBeLessThan(int value) => $"Должно быть меньше чем {value}";

    public static string StringLengthShouldBeBiggerThan(int value) => $"Должно быть больше чем {value}";

    public static string StringContainOnly(string possibleValues) => $"Должно содержать только: {possibleValues}";

    public static string StringImpossibleValue(string possibleValues) => $"Может быть равно только: {possibleValues}";

    public static string StringUnparsableValue() => "Невозможное значение";

    public static string StringWrongFormat() => "Неверный формат";

    public static string DateTimeShouldBeNotFromFuture() => "Дата не может быть в будущем";
}