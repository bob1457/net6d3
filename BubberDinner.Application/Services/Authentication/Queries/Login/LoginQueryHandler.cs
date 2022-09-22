using BubbberDinner.Application.Common.interfaces.Authenticaiton;
using BubbberDinner.Application.Common.interfaces.Persistence;
using BubbberDinner.Application.Services.Authenticaiton.Common;
using BubberDinner.Domain.Entities;
using BubberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BubbberDinner.Application.Services.Authenticaiton.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if(_userRepository.GetUserByEmail(query.email) is not User user)
        {
            // throw  new Exception("Login failed, try it again!");
            return Errors.Authenticaiton.InvalidaCredential;
        }

        if(user.Password != query.password) 
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