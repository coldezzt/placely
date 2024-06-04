using FluentValidation;
using static Placely.Data.Dtos.Validators.ValidatorErrorMessages;

namespace Placely.Data.Dtos.Validators;

public class TenantDtoValidator : AbstractValidator<TenantDto>
{
    public TenantDtoValidator()
    {
        RuleFor(dto => dto.ContactAddress)
            .Must(s => s.Any(c => char.IsLetterOrDigit(c) || char.IsPunctuation(c) || c is '/'))
            .WithMessage(StringWrongFormat());
    }
}