using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea2_CrudApi.Domain.Entities;

namespace Tarea2_CrudApi.Domain.Interfaces
{
    public interface IProductoRepository
    {
     
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int id);
        Task AddAsync(Producto producto);
        void Update(Producto producto);
        void Delete(Producto producto);
        Task<int> SaveChangesAsync();
    }
}
