using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("API/[controller]")]
public class BaseController(IMediator mediator) : ControllerBase
{
    
}