using Application.Interfaces;
using MediatR;

namespace Application.Features.ProductFeature.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ResponseWrapper>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseWrapper> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(new object[] { command.Id }, cancellationToken);

        if (product != null)
        {
            product.Barcode = command.Barcode;
            product.Name = command.Name;
            product.Rate = command.Rate;
            product.Description = command.Description;

            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseWrapper(product.Id);
        }

        return new ResponseWrapper().AddError("Product not found!");
    }
}
