namespace BubbberDinner.Infrastructure;

using BubbberDinner.Application.Common.interfaces;
using BubbberDinner.Application.Common.interfaces.Authenticaiton;
using BubbberDinner.Application.Common.interfaces.Persistence;
using BubbberDinner.Infrastructure.Authentication;
using BubbberDinner.Infrastructure.Persistence;
using BubbberDinner.Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}