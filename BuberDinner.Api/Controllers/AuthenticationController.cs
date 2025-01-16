using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
[AllowAnonymous] //Skips authorization for this whole controller
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public AuthenticationController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterRequest registerRequest)
    {
        var register = _mapper.Map<RegisterCommand>(registerRequest);

        var authResult = await _mediator.Send(register); 
        if(authResult.IsSuccess){
            return Ok(_mapper.Map<AuthenticationResponse>(authResult.Value));
        }
        var error = authResult.Errors.FirstOrDefault();
        return Problem(statusCode: StatusCodes.Status409Conflict, title: error?.Message);   
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest){
        var login = _mapper.Map<LoginQuery>(loginRequest);
        var authResult = await _mediator.Send(login);
        if(authResult.IsSuccess){
            return Ok(_mapper.Map<AuthenticationResponse>(authResult.Value));
        }
        if(authResult.Errors.Any()){
            var error = authResult.Errors.FirstOrDefault();
            return Problem(statusCode: StatusCodes.Status409Conflict, detail: error?.Message);
        }
        return Problem();
    }
}