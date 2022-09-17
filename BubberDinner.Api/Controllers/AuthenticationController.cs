using System.Runtime.InteropServices.ComTypes;
using BubberDinner.Contracts.Authenticaiton;
using BubbberDinner.Application.Services.Authenticaiton;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using BubbberDinner.Api.Controllers;
using BubbberDinner.Application.Services.Authenticaiton.Common;

namespace BubberDinner.Api.Controllers;

// [ApiController]
[Route("auth")]
public class AuthenticaitonController : ApiController //ControllerBase 
{
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;

    public AuthenticaitonController(
        IAuthenticationCommandService authenticationCommandService,
        IAuthenticationQueryService authenticationQueryService)
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> registerResult = _authenticationCommandService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return registerResult.Match(
            registerResult => Ok(MapResult(registerResult)),
            errors => Problem(errors)
        );
        
        // AuthenticationResponse registerResponse = MapResult(registerResult);

        // return Ok(registerResponse);
    }

    private static AuthenticationResponse MapResult(AuthenticationResult registerResult)
    {
        return new AuthenticationResponse(
                    registerResult.user.Id,
                    registerResult.user.FirstName,
                    registerResult.user.LastName,
                    registerResult.user.Email,
                    registerResult.Token);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var loginResult = _authenticationQueryService.Login(            
        request.Email,
        request.Password);

        if(loginResult.IsError && loginResult.FirstError == Domain.Common.Errors.Errors.Authenticaiton.InvalidaCredential)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: loginResult.FirstError.Description);
        }
        return loginResult.Match(
            loginResult => Ok(MapResult(loginResult)),
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