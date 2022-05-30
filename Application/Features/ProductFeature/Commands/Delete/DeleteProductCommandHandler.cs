using Application.Interfaces;
using MediatR;

namespace Application.Features.ProductFeature.Commands.Delete;

public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, ResponseWrapper>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductByIdCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseWrapper> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(new object[] { command.Id }, cancellationToken);

        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseWrapper(product.Id);
        }

        return new ResponseWrapper().AddError("Product not found!");
    }
}
