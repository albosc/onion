using FluentValidation;

namespace Application.Features.ProductFeature.Commands;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Matches("^[a-zA-Z0-9 ]*$");
    }
}
