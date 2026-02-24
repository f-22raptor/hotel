using Application.Auth.AuthCommands;
using Application.Auth.AuthCommands.AuthCommandRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class AuthController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterAuthCommand request)
    {
        var result = await mediator.Send(request);
        return result ? Ok() : BadRequest();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginAuthCommand request)
    {
        var result = await mediator.Send(request);
        return HandleResult(result);
    }
}