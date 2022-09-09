namespace BubbberDinner.Infrastructure;

using BubbberDinner.Application.Common.interfaces;
using BubbberDinner.Application.Common.interfaces.Authenticaiton;
using BubbberDinner.Infrastructure.Authentication;
using BubbberDinner.Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}