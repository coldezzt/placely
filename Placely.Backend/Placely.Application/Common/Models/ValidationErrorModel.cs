namespace Placely.Application.Common.Models;

public class ValidationErrorModel
{
    public string PropertyName { get; set; }
    public string ErrorMessage { get; set; }
    public object AttemptedValue { get; set; }
}