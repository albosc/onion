using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeature.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>?>
    {
        private readonly IApplicationDbContext _context;

        public GetAllProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>?> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var productList = await _context.Products.AsNoTracking().ToListAsync(cancellationToken);
            return productList?.AsReadOnly();
        }
    }
}
