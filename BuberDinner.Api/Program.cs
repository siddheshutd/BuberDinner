var builder = WebApplication.CreateBuilder(args);
{
builder.Services
    .AddPresentation()
    .AddApplicationServices()
    .AddInfraServices(builder.Configuration);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication(); //Adds the Authentication middleware. Authentication just verifies the user if he is who is claims to be
    app.UseAuthorization(); //Adds the Authorization middleware. Authorization determines whether a verified user has access to the features of the system
    app.MapControllers();
    app.Run();
}