using System.Runtime.InteropServices.ComTypes;
using BubberDinner.Contracts.Authenticaiton;
using BubbberDinner.Application.Services.Authenticaiton;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using BubbberDinner.Api.Controllers;
using BubbberDinner.Application.Services.Authenticaiton.Common;
using BubbberDinner.Application.Services.Authenticaiton.Commands.Register;
using BubbberDinner.Application.Services.Authenticaiton.Queries.Login;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace BubberDinner.Api.Controllers;

// [ApiController]
[Route("auth")]
[AllowAnonymous]
public class AuthenticaitonController : ApiController //ControllerBase 
{
    private readonly IMediator _mediatr;
    private readonly IMapper _mapper;
    // private readonly IAuthenticationCommandService _authenticationCommandService;
    // private readonly IAuthenticationQueryService _authenticationQueryService;

    public AuthenticaitonController(
        // IAuthenticationCommandService authenticationCommandService,
        // IAuthenticationQueryService authenticationQueryService,
        IMediator mediatr,
        IMapper mapper)
    {
        // _authenticationCommandService = authenticationCommandService;
        // _authenticationQueryService = authenticationQueryService;
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        // new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

        ErrorOr<AuthenticationResult> registerResult = await _mediatr.Send(command);


        return registerResult.Match(
            registerResult => Ok(_mapper.Map<AuthenticationResponse>(registerResult)),
            errors => Problem(errors)
        );

        // AuthenticationResponse registerResponse = MapResult(registerResult);

        // return Ok(registerResponse);
    }

    // private static AuthenticationResponse MapResult(AuthenticationResult registerResult)
    // {
    //     return new AuthenticationResponse(
    //                 registerResult.user.Id,
    //                 registerResult.user.FirstName,
    //                 registerResult.user.LastName,
    //                 registerResult.user.Email,
    //                 registerResult.Token);
    // }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        // var loginResult = _authenticationQueryService.Login(            
        // request.Email,
        // request.Password);
        var query = _mapper.Map<LoginQuery>(request);
        // new LoginQuery(request.email, request.password);

        var loginResult = await _mediatr.Send(query);

        if (loginResult.IsError && loginResult.FirstError == Domain.Common.Errors.Errors.Authenticaiton.InvalidaCredential)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: loginResult.FirstError.Description);
        }
        return loginResult.Match(
            // loginResult => Ok(MapResult(loginResult)),
            loginResult => Ok(_mapper.Map<AuthenticationResponse>(loginResult)),
            errors => Problem(errors)
        );

        // var loginResponse = new AuthenticationResponse(
        //     loginResult.user.Id,
        //     loginResult.user.FirstName,
        //     loginResult.user.LastName,
        //     loginResult.user.Email,
        //     loginResult.Token);


        // return Ok(loginResponse);
    }


}