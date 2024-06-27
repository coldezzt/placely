using FluentValidation;
using static Placely.WebAPI.Dto.Validators.ValidatorErrorMessages;
using static Placely.WebAPI.Dto.Validators.ValidatorMethods;

namespace Placely.WebAPI.Dto.Validators;

public class SensitiveUserDtoValidator : AbstractValidator<SensitiveUserDto>
{
    public SensitiveUserDtoValidator()
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