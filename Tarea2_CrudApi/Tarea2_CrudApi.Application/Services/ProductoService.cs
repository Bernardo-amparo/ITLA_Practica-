using Tarea2_CrudApi.Application.Contracts;
using Tarea2_CrudApi.Domain.Entities;
using Tarea2_CrudApi.Domain.Interfaces;
using Tarea2_CrudApi.DTOs;

namespace Tarea2_CrudApi.Application.Services
{
    public class ProductoService
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
    }
}
