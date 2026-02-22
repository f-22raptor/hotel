using Domain.Enums;

namespace Application.Rooms.RoomDtos;

public class RoomDto
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public RoomType Type { get; set; }
    public decimal PricePerNight { get; set; }
}