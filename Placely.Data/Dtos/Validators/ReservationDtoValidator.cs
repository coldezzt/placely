using FluentValidation;
using Placely.Data.Models;
using static Placely.Data.Dtos.Validators.ValidatorErrorMessages;
using static Placely.Data.Dtos.Validators.ValidatorMethods;

namespace Placely.Data.Dtos.Validators;

public class ReservationDtoValidator : AbstractValidator<ReservationDto>
{
    public ReservationDtoValidator()
    {
        RuleFor(r => r.ReservationStatus)
            .Must(t => Enum.IsDefined(typeof(ReservationStatus), t ?? ""))
            .WithMessage(StringImpossibleValue(string.Join(" | ", Enum.GetValues<ReservationStatus>())));
        RuleFor(r => r.DeclineReason)
            .Must(dr => dr?.Length < 256)
            .When(r => Enum.TryParse<ReservationStatus>(r.ReservationStatus, out _))
            .WithMessage(StringLengthShouldBeLessThan(256));
        RuleFor(r => r.CreationDateTime)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(IsPast).WithMessage(DateTimeShouldBeNotFromFuture());
        RuleFor(r => r.DurationInDays)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(n => n >= 1).WithMessage(TimeSpanDurationShouldBeMoreThan(1));
        RuleFor(r => r.EntryDate)
            .NotEmpty().WithMessage(NullOrEmpty())
            .Must(IsPast).WithMessage(DateTimeShouldBeNotFromPast());
        RuleFor(r => r.GuestsAmount)
            .NotEmpty().WithMessage(NullOrEmpty());
    }
}