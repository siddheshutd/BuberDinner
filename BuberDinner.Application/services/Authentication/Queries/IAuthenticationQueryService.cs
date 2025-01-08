using FluentResults;

public interface IAuthenticationQueryService
{
    Result<AuthenticationResult> Login(string email, string password);
}