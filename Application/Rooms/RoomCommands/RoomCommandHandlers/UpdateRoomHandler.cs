using Application.Result;
using Application.Rooms.RoomCommands.RoomCommandRequests;
using Application.Rooms.RoomDtos;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.Rooms.RoomCommands.RoomCommandHandlers;

public class UpdateRoomHandler(IRoomRepository roomRepository, IHotelRepository hotelRepository, IMapper mapper)
    : IRequestHandler<UpdateRoomCommand, Result<RoomDto>>
{
    public async Task<Result<RoomDto>> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var errorMessage = "";
        var room = await roomRepository.GetByIdAsync(request.Id, cancellationToken); 
        if (room == null)
            errorMessage += $"room {request.Id} not found";
        if (request.HotelId != null &&
            await hotelRepository.GetByIdAsync(request.HotelId.Value, cancellationToken) == null)
            errorMessage += $"hotel {request.HotelId} not found";
        if (errorMessage != "")
            return Result<RoomDto>.Failure(errorMessage, 404);
        
        mapper.Map(request, room);
        var updatedRoom = await roomRepository.UpdateAsync(room, cancellationToken);
        if (updatedRoom == null)
            return Result<RoomDto>.Failure($"update room failed", 400);
        var updatedRoomDto = mapper.Map<RoomDto>(updatedRoom);
        return Result<RoomDto>.Success(updatedRoomDto);
    }
}