namespace Application.Auth.AuthDtos;

public class LoginAuthDto
{
    public ICollection<string> Roles { get; set; } = [];
    public Guid Id { get; set; }
    public string Jwt { get; set; } = string.Empty;
}