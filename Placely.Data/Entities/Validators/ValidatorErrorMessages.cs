namespace Placely.Data.Entities.Validators;

public static class ValidatorErrorMessages
{
    public static string StringNullOrEmpty(string propName) =>
        $"{propName} can't be null or empty";

    public static string StringLengthLessThan(string propName, int value) =>
        $"{propName} length should be more than {value}";

    public static string StringLengthBiggerThan(string propName, int value) =>
        $"{propName} length should be less that {value}";

    public static string StringContainOnly(string propName, string possibleValues) =>
        $"{propName} should contain only: {possibleValues}";
}