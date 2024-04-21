using FluentValidation;
using static Placely.Data.Dtos.Validators.ValidatorErrorMessages;

namespace Placely.Data.Dtos.Validators;

public class ChatDtoValidator : AbstractValidator<ChatDto>
{
    public ChatDtoValidator()
    {
        RuleFor(c => c.FirstUserId)
            .NotEmpty().WithMessage(StringNullOrEmpty());
        RuleFor(c => c.SecondUserId)
            .NotEmpty().WithMessage(StringNullOrEmpty());
    }
}