using Application.Reservations.ReservationDtos;
using Application.Result;
using MediatR;

namespace Application.Reservations.ReservationCommands.ReservationCommandRequests;

public class InsertReservationCommand : IRequest<Result<ReservationDto>>
{
    public DateTimeOffset CheckInDate { get; set; }
    public DateTimeOffset CheckOutDate { get; set; }
    public Guid GuestId { get; set; }
    public Guid RoomId { get; set; }
}