namespace BuberDinner.Application.services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator){
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public AuthenticationResult Register(string firstName, string lastname, string email, string password){
        var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), firstName, lastname);
        return new AuthenticationResult(Guid.NewGuid(), firstName, lastname, email, "", token);
    }

    public AuthenticationResult Login(string email, string password){
        return new AuthenticationResult(Guid.NewGuid(), "", "", "", email, "token");
    }
}