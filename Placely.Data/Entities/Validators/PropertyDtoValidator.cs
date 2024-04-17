using System.Globalization;
using FluentValidation;
using Placely.Data.Dtos;
using Placely.Data.Models;
using static Placely.Data.Entities.Validators.ValidatorErrorMessages;

namespace Placely.Data.Entities.Validators;

public class PropertyDtoValidator : AbstractValidator<PropertyDto>
{
    public PropertyDtoValidator()
    {
        RuleFor(p => p.OwnerId)
            .NotEmpty().WithMessage(StringNullOrEmpty());
        RuleFor(p => p.PriceList)
            .NotEmpty().WithMessage(StringNullOrEmpty());
        RuleFor(p => p.Type)
            .NotEmpty().WithMessage(StringNullOrEmpty())
            .Must(t => Enum.IsDefined(typeof(PropertyType), t))
            .WithMessage(StringImpossibleValue(string.Join(" | ", Enum.GetValues<PropertyType>())));
        RuleFor(p => p.Address)
            .NotEmpty().WithMessage(StringNullOrEmpty());
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage(StringNullOrEmpty())
            .MinimumLength(100).WithMessage(StringLengthBiggerThan(100))
            .MaximumLength(2048).WithMessage(StringLengthLessThan(2048))
            .Must(s => s.Any(c => char.IsLetter(c) || char.IsPunctuation(c)))
            .WithMessage(StringContainOnly("letters and punctuation"));
        RuleFor(p => p.PublicationDate)
            .NotEmpty().WithMessage(StringNullOrEmpty())
            .Must(pd => DateTime.TryParse(pd, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out _))
            .WithMessage(StringUnparsableValue());
    }
}