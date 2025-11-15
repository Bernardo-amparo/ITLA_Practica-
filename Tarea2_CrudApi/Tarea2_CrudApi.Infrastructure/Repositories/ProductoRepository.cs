using Microsoft.EntityFrameworkCore;
using Tarea2_CrudApi.Domain.Entities;
using Tarea2_CrudApi.Domain.Interfaces;
using Tarea2_CrudApi.Infrastructure.Context;
using static Tarea2_CrudApi.Infrastructure.Repositories.ProductoRepository;

namespace Tarea2_CrudApi.Infrastructure.Repositories
{
    internal class ProductoRepository
    {
        public class ProductoRepository : IProductoRepository
        {
            private readonly ApplicationDbContext _context;

            public ProductoRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Producto>> GetAllAsync() =>
                await _context.Productos.ToListAsync();

            public async Task<Producto> GetByIdAsync(int id) =>
                await _context.Productos.FindAsync(id);

            public async Task AddAsync(Producto producto) =>
                await _context.Productos.AddAsync(producto);

            public void Update(Producto producto) =>
                _context.Productos.Update(producto);

            public void Delete(Producto producto) =>
                _context.Productos.Remove(producto);

            public async Task<int> SaveChangesAsync() =>
                await _context.SaveChangesAsync();
        }
    }
}
