using BuberDinner.Application.common.Errors;
using FluentResults;

namespace BuberDinner.Application.services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository){
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
}