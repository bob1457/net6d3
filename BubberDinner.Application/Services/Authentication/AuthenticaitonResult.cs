namespace BubbberDinner.Application.Services.Authenticaiton
{
    public record AuthenticationResult
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}