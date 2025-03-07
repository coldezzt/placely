using FluentValidation;
using Placely.Domain.Common.Enums;
using static Placely.WebAPI.Dto.Validators.ValidatorErrorMessages;
using static Placely.WebAPI.Dto.Validators.ValidatorMethods;

namespace Placely.WebAPI.Dto.Validators;

public class ReservationDtoValidator : AbstractValidator<ReservationDto>
{
    public ReservationDtoValidator()
    {
        RuleFor(r => r.StatusType)
            .Must(t => Enum.IsDefined(typeof(ReservationStatusType), t))
            .When(r => r.StatusType is ReservationStatusType.Undefined)
            .WithMessage(StringImpossibleValue(string.Join(" | ", Enum.GetValues<ReservationStatusType>())));
        RuleFor(r => r.DeclineReason)
            .Must(dr => dr?.Length < 256)
            .When(r => r.StatusType is not ReservationStatusType.Undefined)
            .WithMessage(StringLengthShouldBeLessThan(256));
        RuleFor(r => r.CreationDateTime)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(IsPast).WithMessage(DateTimeShouldBeNotFromFuture());
        RuleFor(r => r.DurationInDays)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(n => n >= 1).WithMessage(TimeSpanDurationShouldBeMoreThan(1));
        RuleFor(r => r.EntryDate)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(IsFuture).WithMessage(DateTimeShouldBeNotFromPast());
        RuleFor(r => r.GuestsAmount)
            .NotEmpty().WithMessage(NullOrEmpty());
    }
}