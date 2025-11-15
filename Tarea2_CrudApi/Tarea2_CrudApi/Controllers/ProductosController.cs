using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea2_CrudApi.Data;
using Tarea2_CrudApi.Models;
using Tarea2_CrudApi.DTOs;

[Route("api/[Controller]")]
[ApiController]
public class ProductosController : ControllerBase

    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- C R E A T E (POST) ---
        [HttpPost]
        public async Task<ActionResult<ProductoReadDto>> PostProducto(ProductoCreateDto productoDto)
        {
            var producto = new Producto { Nombre = productoDto.Nombre, Precio = productoDto.Precio };
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            var readDto = new ProductoReadDto { Id = producto.Id, Nombre = producto.Nombre, Precio = producto.Precio };
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, readDto);
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoReadDto>>> GetProductos()
        {
            var productos = await _context.Productos.ToListAsync();
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
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

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
            var productoExistente = await _context.Productos.FindAsync(id);
            if (productoExistente == null) return NotFound();

            productoExistente.Nombre = productoDto.Nombre;
            productoExistente.Precio = productoDto.Precio;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    
}
