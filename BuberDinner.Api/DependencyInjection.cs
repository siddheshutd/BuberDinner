
using BuberDinner.Api.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using BuberDinner.Api.Errors;

public static class DependencyInjection {
    public static IServiceCollection AddPresentation(this IServiceCollection services) {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}