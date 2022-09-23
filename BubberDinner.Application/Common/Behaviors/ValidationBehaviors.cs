namespace BubbberDinner.Application.Common.Behaviours;

using System.Threading;
using BubbberDinner.Application.Services.Authenticaiton.Commands.Register;
using BubbberDinner.Application.Services.Authenticaiton.Common;
using MediatR;
using ErrorOr;
using System.Threading.Tasks;
using FluentValidation;

public class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehaviors(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
       

        if(_validator is null)
        {
            return await next();
        }
        
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if(validationResult.IsValid)
        {
            return await next();
        }
        
        var errors = validationResult.Errors
                    .ConvertAll(validationFailure => Error.Validation(
                        validationFailure.PropertyName, 
                        validationFailure.ErrorMessage))
                    .ToList();
        // Before the handler cidevalidationFailure
        // var result = await next();

        // After the handler code

        return (dynamic)errors;
    }

    // public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    // {
    //     throw new NotImplementedException();
    // }
}