using BubberDinner.Domain.Entities;

namespace BubbberDinner.Application.Services.Authenticaiton.Common
{
    public record AuthenticationResult
    (
        User user,
        string Token
    );
}