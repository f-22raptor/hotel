using Application.Reservations.ReservationCommands.ReservationCommandRequests;
using Application.Reservations.ReservationDtos;
using Application.Result;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Reservations.ReservationCommands.ReservationCommandHandlers;

public class DeleteReservationHandler(IReservationRepository reservationRepository, IMapper mapper) : IRequestHandler<DeleteReservationCommand, Result<ReservationDto>>
{
    public async Task<Result<ReservationDto>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await reservationRepository.GetByIdAsync(request.ReservationId, cancellationToken);
        if (reservation == null)
            return Result<ReservationDto>.Failure($"reservation {request.ReservationId} not found", 404);
        if(reservation.GuestId != request.GuestId)
            return Result<ReservationDto>.Failure($"reservation {request.ReservationId} not found", 404);
        reservation = await reservationRepository.DeleteAsync(reservation.Id, cancellationToken);
        var reservationDto = mapper.Map<ReservationDto>(reservation);
        return Result<ReservationDto>.Success(reservationDto);
    }
}