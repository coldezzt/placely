using FluentValidation;
using static Placely.Data.Dtos.Validators.ValidatorErrorMessages;
using static Placely.Data.Dtos.Validators.ValidatorMethods;

namespace Placely.Data.Dtos.Validators;

public class SensitiveTenantDtoValidator : AbstractValidator<SensitiveTenantDto>
{
    public SensitiveTenantDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage(NullOrEmpty());
        RuleFor(dto => dto.PhoneNumber)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(IsPhoneNumber).WithMessage(StringWrongFormat());
        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(IsEmail).WithMessage(StringWrongFormat());
        RuleFor(dto => dto.OldPassword)
            .NotEmpty().WithMessage(NullOrEmpty());
        RuleFor(dto => dto.NewPassword)
            .Must(IsPassword)
            .When(dto => dto.NewPassword is not (null or ""))
            .WithMessage(StringWrongFormat());
    }
}