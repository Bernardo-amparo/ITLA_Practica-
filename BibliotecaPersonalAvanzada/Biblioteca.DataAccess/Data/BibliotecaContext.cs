using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Domain;

namespace Biblioteca.DataAccess.Data
{
    public class BibliotecaContext : DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Autor)
                .WithMany()
                .HasForeignKey(l => l.AutorId);

        }
    }
}