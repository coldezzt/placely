using FluentValidation;
using FluentValidation.Results;
using Placely.Data.Abstractions.Services;
using Placely.Main.Exceptions;

namespace Placely.Main.Services;

public class Validatable<T> : IValidatable<T>
{
    private AbstractValidator<T> Validator { get; init; }
    
    protected Validatable(AbstractValidator<T> validator)
    {
        Validator = validator;
    }
    
    /// <summary>
    /// Валидирует сущность типа T
    /// </summary>
    /// <param name="entity">Сущность для валидации</param>
    /// <returns>Результат валидации</returns>
    /// <exception cref="EntityValidationFailedException">Если валидация закончилась неудачей</exception>
    public async Task<ValidationResult> ValidateUnsafeAsync(T entity)
    {
        var validationResult = await Validator.ValidateAsync(entity);
        if (!validationResult.IsValid)
            throw new EntityValidationFailedException(typeof(T), validationResult.Errors);

        return validationResult;
    }
}