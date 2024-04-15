using FluentValidation;
using static Placely.Data.Entities.Validators.ValidatorErrorMessages;

namespace Placely.Data.Entities.Validators;

public class PropertyValidator : AbstractValidator<Property>
{
    public PropertyValidator()
    {
        RuleFor(p => p.OwnerId)
            .NotEmpty().WithMessage(StringNullOrEmpty("OwnerId"));
        RuleFor(p => p.PriceListId)
            .NotEmpty().WithMessage(StringNullOrEmpty("PriceListId"));
        RuleFor(p => p.Address)
            .NotEmpty().WithMessage(StringNullOrEmpty("Address"));
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage(StringNullOrEmpty("Description"))
            .MinimumLength(100).WithMessage(StringLengthBiggerThan("Description", 100))
            .MaximumLength(2048).WithMessage(StringLengthLessThan("Description", 2048))
            .Must(s => s.Any(c => char.IsLetter(c) || char.IsPunctuation(c)))
            .WithMessage(StringContainOnly("Description", "letters and punctuation"));
    }
}