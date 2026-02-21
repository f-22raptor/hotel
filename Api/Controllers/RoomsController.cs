using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class RoomsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        throw new NotImplementedException();
    }
}