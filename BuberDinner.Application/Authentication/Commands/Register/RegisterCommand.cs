using FluentResults;
using MediatR;

public record struct RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<Result<AuthenticationResult>>;