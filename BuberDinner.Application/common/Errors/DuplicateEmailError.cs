using FluentResults;

namespace BuberDinner.Application.common.Errors;

public class DuplicateEmailError : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => "A User with this email already exists.";

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
