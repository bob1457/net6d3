using BubbberDinner.Application.Services.Authenticaiton.Common;
using ErrorOr;
using MediatR;

namespace BubbberDinner.Application.Services.Authenticaiton.Queries.Login;

public record LoginQuery(
    string email, 
    string password) : IRequest<ErrorOr<AuthenticationResult>>;