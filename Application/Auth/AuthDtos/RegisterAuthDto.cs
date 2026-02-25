namespace Application.Auth.AuthDtos;

public class RegisterAuthDto
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }=string.Empty;
    public ICollection<string> Roles { get; set; } = [];
}