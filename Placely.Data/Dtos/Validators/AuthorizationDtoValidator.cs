using FluentValidation;
using static Placely.Data.Dtos.Validators.ValidatorErrorMessages;
using static Placely.Data.Dtos.Validators.ValidatorMethods;

namespace Placely.Data.Dtos.Validators;

public class AuthorizationDtoValidator : AbstractValidator<AuthorizationDto>
{
    public AuthorizationDtoValidator()
    {
        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(IsEmail).WithMessage(StringWrongFormat());
        RuleFor(dto => dto.Password)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(IsPassword).WithMessage(StringWrongFormat());
    }
}