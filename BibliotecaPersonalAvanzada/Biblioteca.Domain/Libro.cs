using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain
{
    public class Libro : EntidadBase
    {
        public string Titulo { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int AutorId { get; set; } // Foreign Key
        public Autor Autor { get; set; } // Propiedad de Navegación
        public bool EstaPrestado { get; private set; }

        // Constructor por defecto (necesario para EF Core)
        public Libro() { }

        // Constructor con parámetros
        public Libro(string titulo, string isbn, int autorId)
        {
            Titulo = titulo;
            ISBN = isbn;
            AutorId = autorId;
            EstaPrestado = false;
        }

        public override string ObtenerTipoEntidad() => "LIBRO_COLECCIÓN";

        // Sobrecarga de Método 1
        public string ObtenerResumen()
        {
            return $"{Titulo} (ISBN: {ISBN})";
        }

        // Sobrecarga de Método 2
        public string ObtenerResumen(bool incluirEstado)
        {
            string estado = EstaPrestado ? "PRESTADO" : "DISPONIBLE";
            return incluirEstado ? $"{ObtenerResumen()} - Estado: {estado}" : ObtenerResumen();
        }
    }
}
