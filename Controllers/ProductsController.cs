using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private const string NameGetByIdRoute = "GetProductById";

    private readonly IProductService _service;

    public ProductsController(IProductService service) {_service = service;}

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseProductDto>>> GetAllAsync(CancellationToken ct)
    {
        var products = await _service.GetAllAsync(ct);
        return Ok(products.Select(p => p.ToResponse()));
    }

    [HttpGet("{id:int}", Name = NameGetByIdRoute)]
    public async Task<ActionResult<ResponseProductDto>> GetByIdAsync(int id, CancellationToken ct)
    {
        var product = await _service.GetByIdAsync(id, ct);
        return product == null ? NotFound() : Ok(product.ToResponse());
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ResponseProductDto>>> SearchAsync(string name, CancellationToken ct)
    {
        var products = await _service.SearchAsync(name, ct);
        return Ok(products.Select(p => p.ToResponse()));
    }

    [HttpGet("expensive")]
    public async Task<ActionResult<IEnumerable<ResponseProductDto>>> GetExpensiveAsync(decimal minPrice, CancellationToken ct)
    {
        var products = await _service.GetExpensiveAsync(minPrice, ct);
        return Ok(products.Select(p => p.ToResponse()));
    }

    [HttpPost]
    public async Task<ActionResult<ResponseProductDto>> CreateAsync(CreateProductDto dto, CancellationToken ct)
    {
        var created = await _service.CreateAsync(dto.toEntity(), ct);
        return CreatedAtRoute(NameGetByIdRoute, new {id = created.Id}, created.ToResponse());
    }

    [HttpPut]
    public async Task<ActionResult<ResponseProductDto>> UpdateAsync(int id, UpdateProductDto dto, CancellationToken ct)
    {
        var updated = await _service.UpdateAsync(id, dto.ToEntity(), ct);
        return updated == null ? NotFound() : Ok(updated.ToResponse());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        var deleted = await _service.DeleteAsync(id, ct);
        return !deleted ? NotFound() : NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAllAsync(CancellationToken ct)
    {
        await _service.DeleteAllAsync(ct);
        return NoContent();
    }
}