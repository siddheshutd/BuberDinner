using BuberDinner.Application.common.Errors;
using FluentResults;
using MediatR;

namespace BuberDinner.Application.services.Authentication.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository){
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if(_userRepository.GetUserByEmail(request.Email) is not User user){
            return Result.Fail(new InvalidEmailError());
        }

        if(user.Password != request.Password){
            return Result.Fail(new InvalidPasswordError());
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        return Result.Ok(new AuthenticationResult(user, token));
    }
}

