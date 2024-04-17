namespace Placely.Data.Entities.Validators;

public static class ValidatorErrorMessages
{
    public static string StringNullOrEmpty() => "Can't be null or empty";

    public static string StringLengthLessThan(int value) => $"Length should be more than {value}";

    public static string StringLengthBiggerThan(int value) => $"Length should be less that {value}";

    public static string StringContainOnly(string possibleValues) => $"Should contain only: {possibleValues}";

    public static string StringImpossibleValue(string possibleValues) => $"Can be equal only: {possibleValues}";

    public static string StringUnparsableValue() => "Incoming string was in wrong format";
}