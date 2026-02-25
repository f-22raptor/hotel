using Application.Reservations.ReservationCommands.ReservationCommandRequests;
using FluentValidation;

namespace Application.Reservations.ReservationValidators;

public class UpdateReservationValidator : AbstractValidator<InsertReservationCommand>
{
    public UpdateReservationValidator()
    {
        RuleFor(c => c.CheckInDate)
            .NotEmpty().WithMessage("CheckInDate is required")
            .GreaterThanOrEqualTo(DateTimeOffset.UtcNow).WithMessage("CheckInDate cant be in the past");
        RuleFor(c => c.CheckOutDate)
            .NotEmpty().WithMessage("CheckOutDate is required")
            .GreaterThanOrEqualTo(c => c.CheckInDate).WithMessage("CheckOutDate must be after CheckInDate");
        RuleFor(c => c.GuestId)
            .NotEmpty().WithMessage("GuestId is required");
        RuleFor(c => c.RoomId)
            .NotEmpty().WithMessage("RoomId is required");
    }
}