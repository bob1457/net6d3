
namespace BubbberDinner.Application;

using BubbberDinner.Application.Services.Authenticaiton;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddMediatR(typeof(ApplictionAssembly).Assembly);
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

        return services;
    }
}