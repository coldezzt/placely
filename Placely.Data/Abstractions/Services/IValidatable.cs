using FluentValidation.Results;

namespace Placely.Data.Abstractions.Services;

public interface IValidatable<in T>
{
    protected Task<ValidationResult> ValidateUnsafeAsync(T entity);
}