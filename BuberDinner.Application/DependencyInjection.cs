using BuberDinner.Application.common.Interfaces.Services;
using BuberDinner.Application.services.Authentication;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}