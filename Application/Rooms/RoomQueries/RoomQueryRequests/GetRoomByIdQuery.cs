using Application.Rooms.RoomDtos;
using MediatR;

namespace Application.Rooms.RoomQueries.RoomQueryRequests;

public class GetRoomByIdQuery : IRequest<RoomDto?>
{
    public Guid RoomId { get; set; }
}