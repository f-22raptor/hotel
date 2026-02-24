using MediatR;

namespace Application.Auth.AuthCommands.AuthCommandRequests;

public class RegisterAuthCommand : IRequest<bool>
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string[] Roles { get; set; } = [];
}