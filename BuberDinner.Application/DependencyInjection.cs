
using System.Reflection;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped<IPipelineBehavior<RegisterCommand, Result<AuthenticationResult>>, ValidateRegisterCommandBehaviour>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}