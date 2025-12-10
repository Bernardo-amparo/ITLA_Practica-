using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain
{
    public abstract class EntidadBase
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Método abstracto (debe ser implementado por las clases hijas)
        public abstract string ObtenerTipoEntidad();

        public EntidadBase()
        {
            FechaCreacion = DateTime.Now;
        }
    }
}