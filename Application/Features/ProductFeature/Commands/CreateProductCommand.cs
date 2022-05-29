using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductFeature.Commands;

/// <summary>
/// Defines a request for creating a product.
/// </summary>
public class CreateProductCommand : IRequest<int>
{
    #region DTO

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

    #endregion

    #region Handler

   

    #endregion
}
