using Application.Rooms.RoomCommands.RoomCommandRequests;
using Application.Rooms.RoomDtos;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.Rooms.RoomCommands.RoomCommandHandlers;

public class InsertRoomHandlerAsync(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<InsertRoomCommand, RoomDto?>
{
    public async Task<RoomDto?> Handle(InsertRoomCommand request, CancellationToken cancellationToken)
    {
        var room = mapper.Map<Room>(request);
        await roomRepository.InsertAsync(room, cancellationToken);
        var roomDto = mapper.Map<RoomDto>(room);
        return roomDto;
    }
}