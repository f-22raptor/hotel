using Application.Rooms.RoomDtos;
using MediatR;

namespace Application.Rooms.RoomQueries.RoomQueryRequests;

public class GetAllRoomsQuery : IRequest<ICollection<RoomDto>>
{
    // filtering
    public string? FilterOn { get; set; }
    public string? FilterQuery { get; set; }
    // sorting
    public string? OrderBy { get; set; }
    public bool IsAscending { get; set; } = true;
    // pagination
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = int.MaxValue;
}