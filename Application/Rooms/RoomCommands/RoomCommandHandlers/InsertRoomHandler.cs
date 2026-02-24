using Application.Result;
using Application.Rooms.RoomCommands.RoomCommandRequests;
using Application.Rooms.RoomDtos;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.Rooms.RoomCommands.RoomCommandHandlers;

public class InsertRoomHandler(IRoomRepository roomRepository, IHotelRepository hotelRepository, IMapper mapper)
    : IRequestHandler<InsertRoomCommand, Result<RoomDto>>
{
    public async Task<Result<RoomDto>> Handle(InsertRoomCommand request, CancellationToken cancellationToken)
    {
        var errorMessage = "";
        if (request.HotelId != null &&
            !await roomRepository.IsRoomNumberUniqueAsync(request.HotelId.Value, request.Number, cancellationToken))
            errorMessage += $"room {request.Number} already exists";
        if (request.HotelId != null &&
            await hotelRepository.GetByIdAsync(request.HotelId.Value, cancellationToken) == null)
            errorMessage += $"hotel {request.HotelId} not found";
        if (errorMessage != "")
            return Result<RoomDto>.Failure(errorMessage, 404);

        var room = mapper.Map<Room>(request);
        var result = await roomRepository.InsertAsync(room, cancellationToken);
        if (result == null)
            return Result<RoomDto>.Failure($"insert room failed", 400);
        var roomDto = mapper.Map<RoomDto>(room);
        return Result<RoomDto>.Success(roomDto);
    }
}