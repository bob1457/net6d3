using BubberDinner.Contracts.Authenticaiton;
using BubbberDinner.Application.Services.Authenticaiton;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticaitonController: ControllerBase 
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticaitonController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var registerResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);
        
        var registerResponse = new AuthenticationResponse(
            registerResult.user.Id,
            registerResult.user.FirstName,
            registerResult.user.LastName,
            registerResult.user.Email,
            registerResult.Token);

        return Ok(registerResponse);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
         var loginResult = _authenticationService.Login(            
            request.Email,
            request.Password);
        
        var loginResponse = new AuthenticationResponse(
            loginResult.user.Id,
            loginResult.user.FirstName,
            loginResult.user.LastName,
            loginResult.user.Email,
            loginResult.Token);

        
        return Ok(loginResponse);
    }

    
}