using BubberDinner.Domain.Entities;

namespace BubbberDinner.Application.Services.Authenticaiton
{
    public record AuthenticationResult
    (
        User user,
        string Token
    );
}