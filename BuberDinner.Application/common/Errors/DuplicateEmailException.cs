using System.Net;

namespace BuberDinner.Application.common.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public String ErrorMessage => "A User with this email already exists.";
}