using Application.Rooms.RoomDtos;
using MediatR;

namespace Application.Rooms.RoomCommands.RoomCommandRequests;

public class DeleteRoomCommand : IRequest<RoomDto?>
{
    public Guid RoomId { get; set; }
}