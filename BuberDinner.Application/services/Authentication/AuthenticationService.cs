using BuberDinner.Application.common.Errors;
using FluentResults;

namespace BuberDinner.Application.services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository){
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password){
        if(_userRepository.GetUserByEmail(email) is not null){
            return Result.Fail(new DuplicateEmailError());
        }
        var user = new User(){ Email = email, Password = password , FirstName = firstName, LastName = lastName };
        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user);
        return Result.Ok(new AuthenticationResult(user, token)) ;
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