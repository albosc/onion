using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeature.Queries.GetAll;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ResponseWrapper>
{
    private readonly IApplicationDbContext _context;

    public GetAllProductsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseWrapper> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        var productList = await _context.Products.AsNoTracking().ToListAsync(cancellationToken);

        if (productList != null)
        {
            return new ResponseWrapper(productList.AsReadOnly());
        }

        return new ResponseWrapper().AddError("Product not found!");
    }
}
