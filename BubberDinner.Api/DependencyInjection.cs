
namespace BubbberDinner.Api;

using BubbberDinner.Application.Services.Authenticaiton;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using BubbberDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using BubbberDinner.Api.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // services.AddMediatR(typeof(ApplictionAssembly).Assembly);
        // services.AddMediatR(Assembly.GetExecutingAssembly());
        // services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        // services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        services.AddMapping();

        services.AddControllers(); 
        services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();

        return services;
    }
}