using Microsoft.EntityFrameworkCore;
using Tarea2_CrudApi.Domain.Entities;

namespace Tarea2_CrudApi.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}

