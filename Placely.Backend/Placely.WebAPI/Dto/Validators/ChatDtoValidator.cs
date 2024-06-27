using FluentValidation;
using static Placely.WebAPI.Dto.Validators.ValidatorErrorMessages;

namespace Placely.WebAPI.Dto.Validators;

public class ChatDtoValidator : AbstractValidator<ChatDto>
{
    public ChatDtoValidator()
    {
        RuleFor(c => c.Participants)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(p => p.Count == 2).WithMessage(ListLengthShouldBeEqualTo(2));
    }
}