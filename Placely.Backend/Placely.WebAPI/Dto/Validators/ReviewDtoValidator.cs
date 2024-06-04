using FluentValidation;
using static Placely.WebAPI.Dto.Validators.ValidatorErrorMessages;
using static Placely.WebAPI.Dto.Validators.ValidatorMethods;

namespace Placely.WebAPI.Dto.Validators;

public class ReviewDtoValidator : AbstractValidator<ReviewDto>
{
    public ReviewDtoValidator()
    {
        RuleFor(r => r.PropertyId)
            .NotEmpty().WithMessage(NullOrEmpty());
        RuleFor(r => r.Rating)
            .NotEmpty().WithMessage(NullOrEmpty())
            .InclusiveBetween(0, 5).WithMessage(StringImpossibleValue("от 1 до 5 включительно"));
        RuleFor(r => r.Date)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(IsPast).WithMessage(DateTimeShouldBeNotFromFuture());
        RuleFor(r => r.Content)
            .NotEmpty().WithMessage(NullOrEmpty())
            .MaximumLength(1024).WithMessage(StringLengthShouldBeLessThan(1024));
    }
}