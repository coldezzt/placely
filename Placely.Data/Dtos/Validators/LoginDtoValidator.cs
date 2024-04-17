using FluentValidation;
using static Placely.Data.Dtos.Validators.ValidatorErrorMessages;
using static Placely.Data.Dtos.Validators.ValidatorMethods;

namespace Placely.Data.Dtos.Validators;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage(StringNullOrEmpty())
            .Must(IsEmail).WithMessage(StringWrongFormat());
        RuleFor(dto => dto.Password)
            .NotEmpty().WithMessage(StringNullOrEmpty())
            .Must(IsPassword).WithMessage(StringWrongFormat());
    }
}