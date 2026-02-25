using Application.Reservations.ReservationDtos;
using Application.Result;
using MediatR;

namespace Application.Reservations.ReservationQueries.ReservationQueryRequests;

public class GetReservationByIdQuery : IRequest<Result<ReservationDto>>
{
    public Guid ReservationId { get; init; }
    public Guid GuestId { get; init; }
}