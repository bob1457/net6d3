using System.Security.Cryptography;
using BubbberDinner.Application.Common.interfaces.Authenticaiton;
using BubbberDinner.Application.Common.interfaces.Persistence;
using BubbberDinner.Application.Services.Authenticaiton.Common;
using BubberDineer.Application.Common.Error;
using BubberDinner.Domain.Common.Errors;
using BubberDinner.Domain.Entities;
using ErrorOr;

namespace BubbberDinner.Application.Services.Authenticaiton;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    
    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            // throw  new Exception("Login failed, try it again!");
            return Errors.Authenticaiton.InvalidaCredential;
        }

        if(user.Password != password) 
        {
            // throw  new Exception("Login failed");
            return Errors.Authenticaiton.InvalidaCredential;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult( 
            user,
            token
        );
    }
    
}
