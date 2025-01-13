using FluentResults;
using FluentValidation;
using MediatR;

public class ValidateRegisterCommandBehaviour : IPipelineBehavior<RegisterCommand, Result<AuthenticationResult>>
{
    private readonly IValidator<RegisterCommand> _validator;
    public ValidateRegisterCommandBehaviour(IValidator<RegisterCommand> validator){
        _validator = validator;
    }
    public async Task<Result<AuthenticationResult>> Handle(
        RegisterCommand request, 
        RequestHandlerDelegate<Result<AuthenticationResult>> next, 
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if(validationResult.IsValid){
            return await next();
        }
        var errors = validationResult.Errors.ConvertAll(validationFailure => new FluentResults.Error(validationFailure.ErrorMessage));
        //var result = await next();
        return Result.Fail<AuthenticationResult>(errors);
    }
}