using FluentResults;

namespace BuberDinner.Application.common.Errors;

public class InvalidEmailError : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => "No User with this email exists.";

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}