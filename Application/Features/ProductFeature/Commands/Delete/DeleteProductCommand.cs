using MediatR;

namespace Application.Features.ProductFeature.Commands.Delete;

public class DeleteProductByIdCommand : IRequest<ResponseWrapper>
{
    public int Id { get; set; }
}
