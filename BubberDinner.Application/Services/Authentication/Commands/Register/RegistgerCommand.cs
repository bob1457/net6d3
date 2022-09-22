using BubbberDinner.Application.Services.Authenticaiton.Common;
using ErrorOr;
using MediatR;

namespace BubbberDinner.Application.Services.Authenticaiton.Commands.Register;

public record RegisterCommand(
    string firstName,
    string lastName,
    string email,
    string password) : IRequest<ErrorOr<AuthenticationResult>>;