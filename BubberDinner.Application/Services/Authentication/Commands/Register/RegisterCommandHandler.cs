using System.Reflection.Metadata;
using ErrorOr;
using MediatR;
using BubbberDinner.Application.Common.interfaces.Authenticaiton;
using BubbberDinner.Application.Services.Authenticaiton.Common;
using BubbberDinner.Application.Common.interfaces.Persistence;
using BubberDinner.Domain.Common.Errors;
using BubberDinner.Domain.Entities;

namespace BubbberDinner.Application.Services.Authenticaiton.Commands.Register;

public class RegisterCommandHandler : 
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        if(_userRepository.GetUserByEmail(command.Email) is not null)
        {
            // throw  new Exception("User already exists");
            // throw new InvalidOperationException();
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.Add(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user);
                
        return new AuthenticationResult(
            user,
            token
        );
    }
}
