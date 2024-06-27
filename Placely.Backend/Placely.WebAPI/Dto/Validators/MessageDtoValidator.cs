using FluentValidation;
using static Placely.WebAPI.Dto.Validators.ValidatorErrorMessages;
using static Placely.WebAPI.Dto.Validators.ValidatorMethods;

namespace Placely.WebAPI.Dto.Validators;

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
        RuleFor(m => m.FileName)
            .Must(p => Uri.IsWellFormedUriString(p, UriKind.Absolute))
            .When(m => m.FileName is not (null or ""))
            .WithMessage(StringWrongFormat());
    }
}