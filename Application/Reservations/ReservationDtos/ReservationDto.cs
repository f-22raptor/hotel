using Application.Hotels.HotelDtos;
using Application.Rooms.RoomDtos;

namespace Application.Reservations.ReservationDtos;

public class ReservationDto
{
    public Guid Id { get; set; }
    public DateTimeOffset CheckInDate { get; set; }
    public DateTimeOffset CheckOutDate { get; set; }
    public decimal TotalPrice { get; set; }
    public RoomDto? RoomDto { get; set; }
}