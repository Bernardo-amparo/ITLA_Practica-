using Tarea2_CrudApi.Domain.DTOs;

namespace Tarea2_CrudApi.Application.Contracts
{
    public interface IProductoService // Debe ser public
    {
        // NO debe tener llaves {}. Solo la firma y punto y coma.
        Task<IEnumerable<ProductoReadDto>> GetAllProductosAsync();
        Task<ProductoReadDto> GetProductoByIdAsync(int id);
        Task<ProductoReadDto> CreateProductoAsync(ProductoCreateDto dto);
        Task UpdateProductoAsync(int id, ProductoCreateDto dto);
        Task DeleteProductoAsync(int id);
    }
}
