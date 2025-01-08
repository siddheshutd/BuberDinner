using FluentResults;

namespace BuberDinner.Application.common.Errors;

public class InvalidPasswordError : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => "Invalid Password";

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}