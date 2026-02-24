using Application.Rooms.RoomCommands.RoomCommandRequests;
using Application.Rooms.RoomQueries.RoomQueryRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class RoomsController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] GetAllRoomsQuery request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetRoomByIdQuery() { RoomId = id };
        var result = await mediator.Send(request, cancellationToken);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody] InsertRoomCommand request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return HandleResult(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateRoomCommand request,
        CancellationToken cancellationToken)
    {
        request.Id = id;
        var result = await mediator.Send(request, cancellationToken);
        return HandleResult(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteRoomCommand { RoomId = id };
        var result = await mediator.Send(request, cancellationToken);
        return HandleResult(result);
    }
}