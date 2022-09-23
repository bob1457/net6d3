
namespace BubbberDinner.Application;

using BubbberDinner.Application.Services.Authenticaiton;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using BubbberDinner.Application.Services.Authenticaiton.Commands.Register;
using ErrorOr;
using BubbberDinner.Application.Services.Authenticaiton.Common;
using BubbberDinner.Application.Common.Behaviours;
using FluentValidation;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddMediatR(typeof(ApplictionAssembly).Assembly);
        services.AddMediatR(Assembly.GetExecutingAssembly());
        // services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        // services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        services.AddScoped<IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>, ValidationBehaviors>();
        // services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}