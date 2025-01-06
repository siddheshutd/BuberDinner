using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ErrorHandlingFilter : ExceptionFilterAttribute {
    public override void OnException(ExceptionContext exceptionContext) {        
        var problemDetails = new ProblemDetails{
            Type = "Internal Server Error",
            Title = "Some error occured while processing your request.",
            Status = (int)HttpStatusCode.InternalServerError
        };
        exceptionContext.Result = new ObjectResult(problemDetails);
        exceptionContext.ExceptionHandled = true;
    }
}