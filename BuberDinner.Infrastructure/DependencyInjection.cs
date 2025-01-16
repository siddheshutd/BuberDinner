using BuberDinner.Application.common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, ConfigurationManager configuration) {
        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration){
        JwtSettings jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings); //Binds the values from the configuration provider to a strongly typed object

        //services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(//Adds the necessary dependencies needed for Authentication and also returns the Authentication Builder
            defaultScheme: JwtBearerDefaults.AuthenticationScheme //Sets the AuthenticationScheme, which is Bearer in this case.
        )
        .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters{ // Enables JWT-bearer authentication using the default scheme JwtBearerDefaults.AuthenticationScheme
            ValidateIssuer = true, //Sets whether the Issuer will be validated
            ValidateAudience = true, //Sets whether the Audience will be validated
            ValidateLifetime = true, //Sets whether the lifetime will be validated
            ValidateIssuerSigningKey = true, //Sets whether the SecurityKey which signed the SecurityToken will be validated
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret)
            )
        }); 
        return services;
    }
}