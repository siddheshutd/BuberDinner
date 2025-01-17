using System.Net;
using System.Text.Json;

public class ErrorHandlingMiddleware{
    private readonly RequestDelegate _next;
    public ErrorHandlingMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task Invoke(HttpContext context) {
        try {
            await _next(context);
        } 
        catch (Exception e) {
            await HandleExceptionAsync(context, e);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception) {
        var code = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new { error = "An error occured while processing your request"});
        context.Response.StatusCode = (int)code;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(result);
    }
}