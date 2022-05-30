using MediatR;

namespace Application.Features.ProductFeature.Commands.Update;

public class UpdateProductCommand : IRequest<ResponseWrapper>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }
    public decimal Rate { get; set; }
}
