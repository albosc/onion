using Application.Features.ProductFeature.Commands.Create;
using Application.Features.ProductFeature.Commands.Delete;
using Application.Features.ProductFeature.Commands.Update;
using Application.Features.ProductFeature.Queries.GetAll;
using Application.Features.ProductFeature.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private IMediator _mediator = null!;

    /// <summary>
    /// 
    /// </summary>
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
 
    /// <summary>
    /// Creates a product.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response.Result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllProductsQuery()));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }
}
