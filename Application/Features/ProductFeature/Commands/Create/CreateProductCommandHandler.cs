using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductFeature.Commands.Create;

/// <summary>
/// Defines a handler for a create product command.
/// </summary>
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResponseWrapper>
{
    /// <summary>
    /// Database context.
    /// </summary>
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateProductCommandHandler"/> class.
    /// </summary>
    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<ResponseWrapper> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Barcode = command.Barcode,
            Description = command.Description,
            Rate = command.Rate
        };

        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return new ResponseWrapper(product.Id);
    }
}
