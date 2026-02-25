using Application.Reservations.ReservationDtos;
using Application.Result;
using MediatR;

namespace Application.Reservations.ReservationCommands.ReservationCommandRequests;

public class DeleteReservationCommand : IRequest<Result<ReservationDto>>
{
    public Guid ReservationId { get; init; }
    public Guid GuestId { get; init; }
}