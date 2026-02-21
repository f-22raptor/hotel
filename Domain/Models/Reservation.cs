using Domain.Enums;

namespace Domain.Models;

public class Reservation : IBaseModel<Guid>
{
    public Guid Id { get; set; }
    public DateTimeOffset CheckInDate { get; set; }
    public DateTimeOffset CheckOutDate { get; set; }
    public decimal TotalPrice { get; set; }
    // foreign key
    public required Guid GuestId { get; set; }
    public required Guid RoomId { get; set; }
    // navigation property
    public required Guest Guest { get; set; }
    public required Room Room { get; set; }
}