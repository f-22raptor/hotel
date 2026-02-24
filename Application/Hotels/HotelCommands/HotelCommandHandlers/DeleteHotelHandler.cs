using Application.Hotels.HotelCommands.HotelCommandRequests;
using Application.Hotels.HotelDtos;
using Application.Result;
using Application.Rooms.RoomCommands.RoomCommandRequests;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Hotels.HotelCommands.HotelCommandHandlers;

public class DeleteHotelHandler(IHotelRepository hotelRepository, IMapper mapper)
    : IRequestHandler<DeleteHotelCommand, Result<HotelDto>>
{
    public async Task<Result<HotelDto>> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        if (await hotelRepository.GetByIdAsync(request.HotelId, cancellationToken) == null)
            return Result<HotelDto>.Failure($"hotel {request.HotelId} not found", 404);
        var result = await hotelRepository.DeleteAsync(request.HotelId, cancellationToken);
        if (result == null)
            return Result<HotelDto>.Failure($"delete hotel {request.HotelId} failed", 400);
        var hotelDto=mapper.Map< HotelDto>(result);
        return Result<HotelDto>.Success(hotelDto);
    }
}