using FluentValidation;
using static Placely.WebAPI.Dto.Validators.ValidatorErrorMessages;

namespace Placely.WebAPI.Dto.Validators;

public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(dto => dto.ContactAddress)
            .Must(s => s.Any(c => char.IsLetterOrDigit(c) || char.IsPunctuation(c) || c is '/'))
            .WithMessage(StringWrongFormat());
    }
}