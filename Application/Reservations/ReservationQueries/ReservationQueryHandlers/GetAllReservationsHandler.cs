using Application.Reservations.ReservationDtos;
using Application.Reservations.ReservationQueries.ReservationQueryRequests;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Reservations.ReservationQueries.ReservationQueryHandlers;

public class GetAllReservationsHandler(IReservationRepository reservationRepository, IMapper mapper)
    : IRequestHandler<GetAllReservationsQuery, ICollection<ReservationDto>>
{
    public async Task<ICollection<ReservationDto>> Handle(GetAllReservationsQuery request,
        CancellationToken cancellationToken)
    {
        var guestIdString = request.GuestId.ToString();
        var reservations =
            await reservationRepository.GetAllAsync(cancellationToken, filterOn: "GuestId", filterQuery: guestIdString);
        var reservationDtos=mapper.Map<ReservationDto[]>(reservations);
        return reservationDtos;
    }
}