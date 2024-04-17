﻿using FluentValidation;
using static Placely.Data.Dtos.Validators.ValidatorErrorMessages;
using static Placely.Data.Dtos.Validators.ValidatorMethods;

namespace Placely.Data.Dtos.Validators;

public class RegistrationDtoValidator : AbstractValidator<RegistrationDto>
{
    public RegistrationDtoValidator()
    {
        RuleFor(dto => dto.PhoneNumber)
            .NotEmpty().WithMessage(StringNullOrEmpty())
            .Must(IsPhoneNumber).WithMessage(StringWrongFormat());
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage(StringNullOrEmpty())
            .MaximumLength(256).WithMessage(StringLengthShouldBeLessThan(256))
            .Must(s => s.Any(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            .WithMessage(StringContainOnly("буквы русского алфавита и пробелы"));
        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage(StringNullOrEmpty())
            .Must(IsEmail).WithMessage(StringWrongFormat());
        RuleFor(dto => dto.Password)
            .NotEmpty().WithMessage(StringNullOrEmpty())
            .Must(IsPassword).WithMessage(StringWrongFormat());
    }
}