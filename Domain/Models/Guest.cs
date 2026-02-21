namespace Domain.Models;

public class Guest : IBaseModel<Guid>
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    // navigation property
    public ICollection<Reservation> Reservations { get; set; } = [];
}