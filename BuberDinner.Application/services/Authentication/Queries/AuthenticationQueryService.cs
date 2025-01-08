using BuberDinner.Application.common.Errors;
using FluentResults;

namespace BuberDinner.Application.services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository){
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public Result<AuthenticationResult> Login(string email, string password){
        if(_userRepository.GetUserByEmail(email) is not User user){
            return Result.Fail(new InvalidEmailError());
        }

        if(user.Password != password){
            return Result.Fail(new InvalidPasswordError());
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        return Result.Ok(new AuthenticationResult(user, token));
    }
}
