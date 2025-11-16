using Microsoft.AspNetCore.Mvc;
using Tarea2_CrudApi.Application.Contracts;
using Tarea2_CrudApi.Domain.DTOs; 

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{

    private readonly IProductoService _service;

    public ProductosController(IProductoService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<ActionResult<ProductoReadDto>> PostProducto(ProductoCreateDto productoDto)
    {
        var readDto = await _service.CreateProductoAsync(productoDto);


        return CreatedAtAction(nameof(GetProducto), new { id = readDto.Id }, readDto);
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoReadDto>>> GetProductos()
    {
        var productos = await _service.GetAllProductosAsync();


        return Ok(productos);
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoReadDto>> GetProducto(int id)
    {

        var productoDto = await _service.GetProductoByIdAsync(id);

        if (productoDto == null)
        {
            return NotFound();
        }

        return Ok(productoDto);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(int id, ProductoCreateDto productoDto)
    {
        try
        {
            await _service.UpdateProductoAsync(id, productoDto);
        }
        catch (InvalidOperationException) 
        {
            return NotFound();
        }

        return NoContent(); 
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        try
        {
            await _service.DeleteProductoAsync(id);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }

        return NoContent();
    }
}