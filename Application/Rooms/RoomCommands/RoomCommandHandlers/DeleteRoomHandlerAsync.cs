using Application.Rooms.RoomCommands.RoomCommandRequests;
using Application.Rooms.RoomDtos;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Rooms.RoomCommands.RoomCommandHandlers;

public class DeleteRoomHandlerAsync(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<DeleteRoomCommand, RoomDto?>
{
    public async Task<RoomDto?> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.DeleteAsync(request.RoomId, cancellationToken);
        if(room == null)
            return null;
        var roomDto = mapper.Map<RoomDto>(room);
        return  roomDto;
    }
}