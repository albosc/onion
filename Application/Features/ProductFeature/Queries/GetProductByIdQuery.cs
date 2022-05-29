using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeature.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product?>
    {
        private readonly IApplicationDbContext _context;

        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> Handle(GetProductByIdQuery query, CancellationToken cancellationToken) =>
            await _context.Products.AsNoTracking().SingleOrDefaultAsync(a => a.Id == query.Id, cancellationToken);
    }
}
