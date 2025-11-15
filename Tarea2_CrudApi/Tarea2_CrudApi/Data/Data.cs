using Microsoft.EntityFrameworkCore;
using Tarea2_CrudApi.Models;

namespace Tarea2_CrudApi.Data
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

