using System.Net;

public interface IServiceException {
    public HttpStatusCode StatusCode { get; }
    public String ErrorMessage { get; }
}