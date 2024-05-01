using FluentValidation;
using static Placely.Data.Dtos.Validators.ValidatorErrorMessages;
using static Placely.Data.Dtos.Validators.ValidatorMethods;

namespace Placely.Data.Dtos.Validators;

public class TenantDtoValidator : AbstractValidator<TenantDto>
{
    public TenantDtoValidator()
    {
        RuleFor(dto => dto.AvatarPath)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(s => Uri.IsWellFormedUriString(s, UriKind.Absolute))
            .WithMessage(StringWrongFormat());
        RuleFor(dto => dto.ContactAddress)
            .Must(s => s.Any(c => char.IsLetterOrDigit(c) || char.IsPunctuation(c) || c is '/'))
            .WithMessage(StringWrongFormat());
    }
}