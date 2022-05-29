using Application.Features.ErrorFeature;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage))
                .ToArray();

            var errorResponse = new ErrorResponse();
            foreach (var error in errors)
            {
                foreach (var suberror in error.Value!)
                {
                    errorResponse.Errors.Add(
                        new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = suberror
                        });
                }
            }

            context.Result = new BadRequestObjectResult(errorResponse);
            return;
        }

        await next();
    }
}
