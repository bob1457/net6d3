using System.Security.Cryptography;
using BubbberDinner.Application.Common.interfaces.Authenticaiton;
using BubbberDinner.Application.Common.interfaces.Persistence;
using BubberDineer.Application.Common.Error;
using BubberDinner.Domain.Common.Errors;
using BubberDinner.Domain.Entities;
using ErrorOr;

namespace BubbberDinner.Application.Services.Authenticaiton;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
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

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            // throw  new Exception("User already exists");
            // throw new InvalidOperationException();
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user);
                
        return new AuthenticationResult(
            user,
            token
        );
        
    }
}
