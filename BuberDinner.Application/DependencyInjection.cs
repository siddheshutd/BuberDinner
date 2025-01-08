
using BuberDinner.Application.services.Authentication.Commands;
using BuberDinner.Application.services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        return services;
    }
}