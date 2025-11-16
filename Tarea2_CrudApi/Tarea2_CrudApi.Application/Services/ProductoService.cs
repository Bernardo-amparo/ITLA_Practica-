using Tarea2_CrudApi.Application.Contracts;
using Tarea2_CrudApi.Domain.Entities;
using Tarea2_CrudApi.Domain.Interfaces;
using Tarea2_CrudApi.Domain.DTOs;

namespace Tarea2_CrudApi.Application.Services
{

    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductoReadDto> CreateProductoAsync(ProductoCreateDto dto)
        {
            var producto = new Producto { Nombre = dto.Nombre, Precio = dto.Precio };

            await _repository.AddAsync(producto);
            await _repository.SaveChangesAsync();

            return new ProductoReadDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio
            };
        }


        public async Task<IEnumerable<ProductoReadDto>> GetAllProductosAsync()
        {
            var productos = await _repository.GetAllAsync();

            return productos.Select(p => new ProductoReadDto { Id = p.Id, Nombre = p.Nombre, Precio = p.Precio });
        }

        public async Task<ProductoReadDto> GetProductoByIdAsync(int id)
        {
            var producto = await _repository.GetByIdAsync(id);
            if (producto == null) return null; 

            return new ProductoReadDto { Id = producto.Id, Nombre = producto.Nombre, Precio = producto.Precio };
        }

        public async Task UpdateProductoAsync(int id, ProductoCreateDto dto)
        {
            var productoExistente = await _repository.GetByIdAsync(id);

            if (productoExistente == null)
            {
                throw new InvalidOperationException($"Producto con ID {id} no encontrado.");
            }

            productoExistente.Nombre = dto.Nombre;
            productoExistente.Precio = dto.Precio;

            _repository.Update(productoExistente);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteProductoAsync(int id)
        {
            var producto = await _repository.GetByIdAsync(id);

            if (producto == null)
            {
                throw new InvalidOperationException($"Producto con ID {id} no encontrado.");
            }

            _repository.Delete(producto);
            await _repository.SaveChangesAsync();
        }
    }
}
