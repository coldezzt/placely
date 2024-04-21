using FluentValidation;
using static Placely.Data.Dtos.Validators.ValidatorErrorMessages;
using static Placely.Data.Dtos.Validators.ValidatorMethods;

namespace Placely.Data.Dtos.Validators;

public class MessageDtoValidator : AbstractValidator<MessageDto>
{
    public MessageDtoValidator()
    {
        RuleFor(m => m.ChatId)
            .NotEmpty().WithMessage(StringNullOrEmpty());
        RuleFor(m => m.AuthorId)
            .NotEmpty().WithMessage(StringNullOrEmpty());
        RuleFor(m => m.Content)
            .NotEmpty().WithMessage(StringNullOrEmpty())
            .MaximumLength(512).WithMessage(StringLengthShouldBeLessThan(512));
        RuleFor(m => m.Date)
            .NotEmpty().WithMessage(StringNullOrEmpty())
            .Must(m => !IsFuture(m)).WithMessage(DateTimeShouldBeNotFromFuture());
        RuleFor(m => m.FilePath)
            .Must(p => Uri.IsWellFormedUriString(p, UriKind.Absolute))
            .When(m => m.FilePath is not (null or ""));
    }
}