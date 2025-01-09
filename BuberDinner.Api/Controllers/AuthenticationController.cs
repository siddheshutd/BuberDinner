using BuberDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthenticationController(IMediator mediator){
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterRequest registerRequest)
    {
        var register = new RegisterCommand(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email, registerRequest.Password);

        var authResult = await _mediator.Send(register); 
        if(authResult.IsSuccess){
            return Ok(MapAuthResult(authResult.Value));
        }
        var error = authResult.Errors.FirstOrDefault();
        return Problem(statusCode: StatusCodes.Status409Conflict, title: error?.Message);   
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(authResult.User.UserId, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest){
        var login = new LoginQuery(loginRequest.Email, loginRequest.Password);
        var authResult = await _mediator.Send(login);
        if(authResult.IsSuccess){
            return Ok(MapAuthResult(authResult.Value));
        }
        if(authResult.Errors.Any()){
            var error = authResult.Errors.FirstOrDefault();
            return Problem(statusCode: StatusCodes.Status409Conflict, detail: error?.Message);
        }
        return Problem();
    }
}
