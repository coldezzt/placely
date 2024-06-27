using FluentValidation;
using static Placely.WebAPI.Dto.Validators.ValidatorErrorMessages;
using static Placely.WebAPI.Dto.Validators.ValidatorMethods;

namespace Placely.WebAPI.Dto.Validators;

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