using Domain.Entities;
using MediatR;

namespace Application.Features.ProductFeature.Queries.GetById;

public class GetProductByIdQuery : IRequest<ResponseWrapper>
{
    public int Id { get; set; }
}
