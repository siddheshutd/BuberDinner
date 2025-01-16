using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("dinners")]
[Authorize]
public class DinnerController : ControllerBase
{
    [HttpGet("getDinners")]
    public IActionResult GetAllDinners(){
        return Ok(new List<object>());
    }
}