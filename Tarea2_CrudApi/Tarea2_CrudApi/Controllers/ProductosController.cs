using Microsoft.AspNetCore.Mvc;
using Tarea2_CrudApi.Domain.Entities; 
using Tarea2_CrudApi.Domain.Interfaces; 
using Tarea2_CrudApi.DTOs; 

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{

    private readonly IProductoRepository _repository;

    public ProductosController(IProductoRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<ProductoReadDto>> PostProducto(ProductoCreateDto productoDto)
    {
        var producto = new Producto
        {
            Nombre = productoDto.Nombre,
            Precio = productoDto.Precio
        };

        await _repository.AddAsync(producto);
        await _repository.SaveChangesAsync(); 

        var readDto = new ProductoReadDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio
        };

        return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, readDto);
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoReadDto>>> GetProductos()
    {
        var productos = await _repository.GetAllAsync();

        return Ok(productos.Select(p => new ProductoReadDto
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Precio = p.Precio
        }).ToList());
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoReadDto>> GetProducto(int id)
    {

        var producto = await _repository.GetByIdAsync(id);

        if (producto == null)
        {
            return NotFound(); 
        }

        var productoDto = new ProductoReadDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio
        };

        return Ok(productoDto); 
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(int id, ProductoCreateDto productoDto)
    {

        var productoExistente = await _repository.GetByIdAsync(id);

        if (productoExistente == null)
        {
            return NotFound();
        }

        productoExistente.Nombre = productoDto.Nombre;
        productoExistente.Precio = productoDto.Precio;

        _repository.Update(productoExistente);
        await _repository.SaveChangesAsync();

        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {

        var producto = await _repository.GetByIdAsync(id);
        if (producto == null)
        {
            return NotFound();
        }

        _repository.Delete(producto);
        await _repository.SaveChangesAsync(); 

        return NoContent(); 
    }
}