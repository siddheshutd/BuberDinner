using BuberDinner.Application.common.Errors;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryCommandService;
    public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService){
        this._authenticationCommandService = authenticationCommandService;
        this._authenticationQueryCommandService = authenticationQueryService;
    }

    [HttpPost("register")]
    public IActionResult RegisterUser(RegisterRequest registerRequest)
    {
        var authResult = _authenticationCommandService.Register(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email, registerRequest.Password);
        if (authResult.IsSuccess)
        {
            return Ok(MapAuthResult(authResult.Value));
        }
        var error = authResult.Errors.FirstOrDefault();
        if(error is DuplicateEmailError){
            return Problem(statusCode: StatusCodes.Status409Conflict, detail: error.Message);
        }
        return Problem();
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(authResult.User.UserId, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest){
        var authResult = _authenticationQueryCommandService.Login(loginRequest.Email, loginRequest.Password);
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
