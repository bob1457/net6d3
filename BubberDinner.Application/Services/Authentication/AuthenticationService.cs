using BubbberDinner.Application.Common.interfaces.Authenticaiton;

namespace BubbberDinner.Application.Services.Authenticaiton;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string token)
    {
        
        return new AuthenticationResult( 
            Guid.NewGuid(),
            "firstName",
            "lastName",           
            email,
            "token"
        );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {

        Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
                
        return new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            token
        );
        
    }
}
