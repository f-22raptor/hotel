using Application.Rooms.RoomCommands.RoomCommandRequests;
using Application.Rooms.RoomDtos;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.Rooms.RoomCommands.RoomCommandHandlers;

public class UpdateRoomHandlerAsync(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<UpdateRoomCommand, RoomDto?>
{
    public async Task<RoomDto?> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = mapper.Map<Room>(request);
        if (room == null)
            return null;
        await roomRepository.UpdateAsync(room, cancellationToken);
        var roomDto = mapper.Map<RoomDto>(room);
        return roomDto;
    }
}