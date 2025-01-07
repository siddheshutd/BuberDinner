using BuberDinner.Application.common.Errors;

namespace BuberDinner.Application.services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository){
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public AuthenticationResult Register(string firstName, string lastName, string email, string password){
        if(_userRepository.GetUserByEmail(email) is not null){
            throw new DuplicateEmailException();
        }
        var user = new User(){ Email = email, Password = password , FirstName = firstName, LastName = lastName };
        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password){
        if(_userRepository.GetUserByEmail(email) is not User user){
            throw new Exception("User with given email does not exist!");
        }

        if(user.Password != password){
            throw new Exception("Invalid Password");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}