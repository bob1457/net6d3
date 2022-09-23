using BubbberDinner.Application.Services.Authenticaiton.Common;
using ErrorOr;
using MediatR;

namespace BubbberDinner.Application.Services.Authenticaiton.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;