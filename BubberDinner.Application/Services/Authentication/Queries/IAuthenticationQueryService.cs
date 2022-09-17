using BubbberDinner.Application.Services.Authenticaiton.Common;
using ErrorOr;

namespace BubbberDinner.Application.Services.Authenticaiton;

public interface IAuthenticationQueryService 
{
    ErrorOr<AuthenticationResult> Login(string email, string password);

}
