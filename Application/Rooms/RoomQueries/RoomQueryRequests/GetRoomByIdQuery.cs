using Application.Result;
using Application.Rooms.RoomDtos;
using MediatR;

namespace Application.Rooms.RoomQueries.RoomQueryRequests;

public class GetRoomByIdQuery : IRequest<Result<RoomDto>>
{
    public Guid RoomId { get; set; }
}