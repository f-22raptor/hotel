using Application.Result;
using Application.Rooms.RoomDtos;
using MediatR;

namespace Application.Rooms.RoomCommands.RoomCommandRequests;

public class DeleteRoomCommand : IRequest<Result<RoomDto>>
{
    public Guid RoomId { get; set; }
}