using FluentValidation;
using static Placely.Data.Dtos.Validators.ValidatorErrorMessages;
using static Placely.Data.Dtos.Validators.ValidatorMethods;

namespace Placely.Data.Dtos.Validators;

public class MessageDtoValidator : AbstractValidator<MessageDto>
{
    public MessageDtoValidator()
    {
        RuleFor(m => m.ChatId)
            .NotEmpty().WithMessage(NullOrEmpty());
        RuleFor(m => m.AuthorId)
            .NotEmpty().WithMessage(NullOrEmpty());
        RuleFor(m => m.Content)
            .NotEmpty().WithMessage(NullOrEmpty())
            .MaximumLength(512).WithMessage(StringLengthShouldBeLessThan(512));
        RuleFor(m => m.Date)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(m => !IsFuture(m)).WithMessage(DateTimeShouldBeNotFromFuture());
        RuleFor(m => m.FilePath)
            .Must(p => Uri.IsWellFormedUriString(p, UriKind.Absolute))
            .When(m => m.FilePath is not (null or ""));
    }
}