using BubbberDinner.Application.Services.Authenticaiton.Common;
using ErrorOr;

namespace BubbberDinner.Application.Services.Authenticaiton;

public interface IAuthenticationCommandService 
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

}
