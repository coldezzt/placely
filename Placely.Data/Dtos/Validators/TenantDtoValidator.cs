using FluentValidation;
using static Placely.Data.Dtos.Validators.ValidatorErrorMessages;
using static Placely.Data.Dtos.Validators.ValidatorMethods;

namespace Placely.Data.Dtos.Validators;

public class TenantDtoValidator : AbstractValidator<TenantDto>
{
    public TenantDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage(NullOrEmpty());
        RuleFor(dto => dto.PhoneNumber)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(IsPhoneNumber).WithMessage(StringWrongFormat());
        RuleFor(dto => dto.AvatarPath)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(s => Uri.IsWellFormedUriString(s, UriKind.Absolute))
            .WithMessage(StringWrongFormat());
    }
}