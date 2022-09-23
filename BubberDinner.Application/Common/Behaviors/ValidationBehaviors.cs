namespace BubbberDinner.Application.Common.Behaviours;

using System.Threading;
using BubbberDinner.Application.Services.Authenticaiton.Commands.Register;
using BubbberDinner.Application.Services.Authenticaiton.Common;
using MediatR;
using ErrorOr;
using System.Threading.Tasks;
using FluentValidation;

public class ValidationBehaviors : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IValidator<RegisterCommand> _validator;

    public ValidationBehaviors(IValidator<RegisterCommand> validator)
    {
        _validator = validator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next)
    {
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

        return errors;
    }
}