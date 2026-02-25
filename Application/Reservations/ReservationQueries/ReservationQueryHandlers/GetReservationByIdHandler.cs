using Application.Reservations.ReservationDtos;
using Application.Reservations.ReservationQueries.ReservationQueryRequests;
using Application.Result;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Application.Reservations.ReservationQueries.ReservationQueryHandlers;

public class GetReservationByIdHandler(IReservationRepository reservationRepository, IMapper mapper) : IRequestHandler<GetReservationByIdQuery, Result<ReservationDto>>
{
    public async Task<Result<ReservationDto>> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var reservation = await reservationRepository.GetByIdAsync(request.ReservationId, cancellationToken);
        if (reservation == null)
            return Result<ReservationDto>.Failure($"reservation {request.ReservationId} not found", 404);
        if(reservation.GuestId != request.GuestId)
            return Result<ReservationDto>.Failure($"reservation {request.ReservationId} not found", 404);
        var reservationDto = mapper.Map<ReservationDto>(reservation);
        return Result<ReservationDto>.Success(reservationDto);
    }
}