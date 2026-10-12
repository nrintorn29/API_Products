using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var product = _service.GetById(id);

        if (product == null)
            return NotFound("ไม่พบข้อมูล");
        
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(Product newProduct)
    {
        if (!_service.IsValid(newProduct))
            return BadRequest("กรุณาใส่ข้อมูลให้ถูกต้อง");
        
        var created = _service.Create(newProduct);

        return CreatedAtAction(nameof(GetById), new {id = created.Id}, created);
    }

    [HttpGet("search")]
    public IActionResult Search(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("กรุณาระบุชื่อสินค้า");

        var products = _service.Search(name);

        if (!products.Any())
            return NotFound("ไม่พบข้อมูล");
        
        return Ok(products);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Product updated)
    {
        if (_service.GetById(id) == null) 
            return NotFound("ไม่พบข้อมูล");

        if (!_service.IsValid(updated))
            return BadRequest("กรุณาใส่ข้อมูลให้ถูกต้อง");

        return Ok(_service.Update(id, updated));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (!_service.Delete(id))
            return NotFound("ไม่พบข้อมูล");
        
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeleteAll()
    {
        _service.DeleteAll();

        return NoContent();
    }

    [HttpGet("expensive")]
    public IActionResult GetExpensive(decimal minPrice)
    {
        var products = _service.GetExpensive(minPrice);

        if (!products.Any())
            return NotFound("ไม่พบข้อมูล");

        return Ok(products);
    }
}
