namespace Domain.Models;

public class Hotel : IBaseModel<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public float Rating { get; set; }
    public Guid Id { get; set; }
    // navigation property
    public ICollection<Room> Rooms { get; set; } = [];
}
