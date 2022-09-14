using System.Data;
using BubberDineer.Api.Common.Error;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BubbberDinner.Api.Controllers;

public class ErrorController: ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        
        var (statusCode, message) = exception switch
        {
            InvalidOperationException => (StatusCodes.Status409Conflict, "user email already exists!"),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured!")
        };
        
        // return Problem(title: exception?.Message,
        //     statusCode: 500);

        return Problem(statusCode: statusCode, title: message);
        // return Problem();
    }
}