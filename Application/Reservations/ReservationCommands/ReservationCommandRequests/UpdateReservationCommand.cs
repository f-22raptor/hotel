using Application.Reservations.ReservationDtos;
using Application.Result;
using MediatR;

namespace Application.Reservations.ReservationCommands.ReservationCommandRequests;

public class UpdateReservationCommand : IRequest<Result<ReservationDto>>
{   
    public Guid GuestId { get; set; }
    public Guid ReservationId { get; set; }
    public DateTimeOffset CheckInDate { get; set; }
    public DateTimeOffset CheckOutDate { get; set; }
    // foreign key
    public Guid RoomId { get; set; }
}