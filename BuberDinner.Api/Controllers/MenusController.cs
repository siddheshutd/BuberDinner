using BuberDinner.Contracts.Menu;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("menus/{hostId}")]
public class MenusController : ControllerBase
{
    [HttpPost("CreateMenu")]
    public IActionResult CreateMenu(CreateMenuRequest request, string hostId){
        return Ok(request);
    }
}