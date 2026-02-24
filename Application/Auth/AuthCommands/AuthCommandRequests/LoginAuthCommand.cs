using Application.Auth.AuthDtos;
using Application.Result;
using MediatR;

namespace Application.Auth.AuthCommands.AuthCommandRequests;

public class LoginAuthCommand : IRequest<Result<LoginAuthDto>>
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}