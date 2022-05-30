using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.PipelineBehaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResponseWrapper
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = null!;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null);

        return failures.Any()
                ? Errors(failures)
                : await next();
    }

    private static TResponse Errors(in IEnumerable<ValidationFailure> failures)
    {
        var response = new ResponseWrapper();

        foreach (var failure in failures)
        {
            response.AddError(failure.ErrorMessage);
        }

        return (TResponse)response;
    }
}
