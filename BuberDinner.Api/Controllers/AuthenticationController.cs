using BuberDinner.Application.services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService){
        this._authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult RegisterUser(RegisterRequest registerRequest){
        var authResult = _authenticationService.Register(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email, registerRequest.Password);
        var result = new AuthenticationResponse(authResult.User.UserId, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
        return Ok(result);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest){
        var authResult = _authenticationService.Login(loginRequest.Email, loginRequest.Password);
        var result = new AuthenticationResponse(authResult.User.UserId, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
        return Ok(result);
    }
}
