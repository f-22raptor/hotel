using Application.Rooms.RoomCommands.RoomCommandRequests;
using FluentValidation;

namespace Application.Validators.RoomValidators;

public class InsertRoomValidator : AbstractValidator<InsertRoomCommand>
{
    public InsertRoomValidator()
    {
        RuleFor(irc => irc.Number).GreaterThan(0).WithMessage("room Number must be positive");
        // RuleFor(irc=>irc.Number)
        RuleFor(irc => irc.HotelId).NotEmpty().WithMessage("HotelId is required");
    }
}