using Application.Rooms.RoomCommands.RoomCommandRequests;
using Application.Rooms.RoomQueries.RoomQueryRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class HotelsController(IMediator mediator) : BaseController(mediator)
{
    // [HttpGet]
    // public async Task<IActionResult> GetAllAsync([FromQuery] GetAllHotelsQuery request,
    //     CancellationToken cancellationToken)
    // {
    //     try
    //     {
    //         var response = await mediator.Send(request, cancellationToken);
    //         return Ok(response);
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e);
    //     }
    // }
    //
    // [HttpGet("{id:guid}")]
    // public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    // {
    //     var request = new GetRoomByIdQuery() { RoomId = id };
    //     var response = await mediator.Send(request, cancellationToken);
    //     if (response == null)
    //         return NotFound($"room {id}  not found");
    //     return Ok(response);
    // }
    //
    // [HttpPost]
    // public async Task<IActionResult> InsertAsync([FromBody] InsertRoomCommand request,
    //     CancellationToken cancellationToken)
    // {
    //     try
    //     {
    //         var response = await mediator.Send(request, cancellationToken);
    //         return Ok(response);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         throw;
    //     }
    // }
    //
    // [HttpPut("{id:guid}")]
    // public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateRoomCommand request,
    //     CancellationToken cancellationToken)
    // {
    //     request.Id = id;
    //     var response = await mediator.Send(request, cancellationToken);
    //     if(response==null)
    //         return NotFound($"room {id}  not found");
    //     return Ok(response);
    // }
    //
    // [HttpDelete("{id:guid}")]
    // public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    // {
    //     var request = new DeleteRoomCommand
    //     {
    //         RoomId = id
    //     };
    //     var response = await mediator.Send(request, cancellationToken);
    //     if (response == null)
    //         return NotFound($"room {id} not found");
    //     return Ok(response);
    // }
}