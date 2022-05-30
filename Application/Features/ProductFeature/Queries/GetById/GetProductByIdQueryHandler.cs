using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeature.Queries.GetById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ResponseWrapper>
{
    private readonly IApplicationDbContext _context;

    public GetProductByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseWrapper> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _context.Products.AsNoTracking().SingleOrDefaultAsync(a => a.Id == query.Id, cancellationToken);

        if (product != null)
        {
            return new ResponseWrapper(product);
        }

        return new ResponseWrapper().AddError("Product not found!");
    }
}
