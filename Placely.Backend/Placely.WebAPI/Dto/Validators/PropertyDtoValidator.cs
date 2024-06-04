using FluentValidation;
using Placely.Domain.Enums;
using static Placely.WebAPI.Dto.Validators.ValidatorErrorMessages;
using static Placely.WebAPI.Dto.Validators.ValidatorMethods;

namespace Placely.WebAPI.Dto.Validators;

public class PropertyDtoValidator : AbstractValidator<PropertyDto>
{
    public PropertyDtoValidator()
    {
        RuleFor(p => p.ShortPeriodPayment)
            .NotEmpty().WithMessage(NullOrEmpty());
        RuleFor(p => p.MediumPeriodPayment)
            .NotEmpty().WithMessage(NullOrEmpty());
        RuleFor(p => p.LongPeriodPayment)            
            .NotEmpty().WithMessage(NullOrEmpty());
        RuleFor(p => p.Type)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(t => Enum.IsDefined(typeof(PropertyType), t))
            .WithMessage(StringImpossibleValue(string.Join(" | ", Enum.GetValues<PropertyType>())));
        RuleFor(p => p.Address)
            .NotEmpty().WithMessage(NullOrEmpty());
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage(NullOrEmpty())
            .MinimumLength(100).WithMessage(StringLengthShouldBeBiggerThan(100))
            .MaximumLength(2048).WithMessage(StringLengthShouldBeLessThan(2048))
            .Must(s => s.Any(c => char.IsLetter(c) || char.IsPunctuation(c)))
            .WithMessage(StringContainOnly("буквы и символы пунктуации"));
        RuleFor(p => p.PublicationDate)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(IsPast).WithMessage(DateTimeShouldBeNotFromFuture());
    }
}