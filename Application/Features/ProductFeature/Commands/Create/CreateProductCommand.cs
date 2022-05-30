using MediatR;

namespace Application.Features.ProductFeature.Commands.Create;

/// <summary>
/// Defines a request for creating a product.
/// </summary>
public class CreateProductCommand : IRequest<ResponseWrapper>
{
    /// <summary>
    /// Name of the product.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Barcode of the product.
    /// </summary>
    public string? Barcode { get; set; }

    /// <summary>
    /// Description of the product.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Rate of the product.
    /// </summary>
    public decimal Rate { get; set; }
}
