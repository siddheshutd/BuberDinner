using FluentResults;

public interface IAuthenticationCommandService
{
    Result<AuthenticationResult> Register(string firstName, string lastname, string email, string password);
}