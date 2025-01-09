using FluentResults;
using MediatR;

public record struct LoginQuery(
    string Email,
    string Password
) : IRequest<Result<AuthenticationResult>>;