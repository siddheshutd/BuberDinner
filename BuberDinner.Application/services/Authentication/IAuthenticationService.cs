using FluentResults;

namespace BuberDinner.Application.services.Authentication;

public interface IAuthenticationService
{
    Result<AuthenticationResult> Register(string firstName, string lastname, string email, string password);
    Result<AuthenticationResult> Login(string email, string password);
}