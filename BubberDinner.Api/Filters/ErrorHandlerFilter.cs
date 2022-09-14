using System.Net;
using System.Runtime.Serialization;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BubbberDinner.Api.Filters;

public class ErrorHandlerFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Title = "An error occured while processing the request",
            Status = (int)HttpStatusCode.InternalServerError
        };
        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;
        
    }
}