using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.DataAccess.Data;
using Biblioteca.Domain;

[Route("api/[controller]")]
[ApiController]
public class LibrosController : ControllerBase
{
    private readonly BibliotecaContext _context;

    // Inyección del DAL
    public LibrosController(BibliotecaContext context)
    {
        _context = context;
    }

    // Endpoint GET: api/Libros
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
    {
        // Accede a la BD a través del Contexto (DAL)
        return await _context.Libros.Include(l => l.Autor).ToListAsync();
    }
}