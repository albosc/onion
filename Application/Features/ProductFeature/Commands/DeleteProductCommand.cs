using Application.Interfaces;
using MediatR;

namespace Application.Features.ProductFeature.Commands;

public class DeleteProductByIdCommand : IRequest<int>
{
    public int Id { get; set; }

    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(new object[] { command.Id }, cancellationToken);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
                return product.Id;
            }
            return default;
        }
    }
}
