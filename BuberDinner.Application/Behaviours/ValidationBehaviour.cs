using FluentResults;
using FluentValidation;
using MediatR;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest>? _validator;
    public ValidationBehaviour(IValidator<TRequest>? validator = null){
        _validator = validator;
    }
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if(_validator is null){
            return await next();
        }
        var validationResult = await _validator.ValidateAsync(request);
        if(validationResult.IsValid){
            return await next();
        }
        var errors = validationResult.Errors.ConvertAll(validationFailure => new FluentResults.Error(validationFailure.ErrorMessage));
        return (dynamic)Result.Fail(errors);
    }
}