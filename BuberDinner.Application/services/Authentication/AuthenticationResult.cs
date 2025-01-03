namespace BuberDinner.Application.services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);