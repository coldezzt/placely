using FluentValidation;
using static Placely.WebAPI.Dto.Validators.ValidatorErrorMessages;

namespace Placely.WebAPI.Dto.Validators;

public class TenantDtoValidator : AbstractValidator<TenantDto>
{
    public TenantDtoValidator()
    {
        RuleFor(dto => dto.ContactAddress)
            .Must(s => s.Any(c => char.IsLetterOrDigit(c) || char.IsPunctuation(c) || c is '/'))
            .WithMessage(StringWrongFormat());
    }
}