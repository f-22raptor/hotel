using Application.Reservations.ReservationDtos;
using MediatR;

namespace Application.Reservations.ReservationQueries.ReservationQueryRequests;

public class GetAllReservationsQuery : IRequest<ICollection<ReservationDto>>
{
    public Guid GuestId { get; init; }
}