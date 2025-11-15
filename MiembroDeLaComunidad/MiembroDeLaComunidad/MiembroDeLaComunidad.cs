using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiembroDeLaComunidad
{
    public abstract class Miembrosbase
    {
        public string Nombre { get; set; }
        public int Identificador { get; set; }

        public Miembrosbase (string nombre, int id)
        {
            Nombre = nombre;
            Identificador = id;
        }

        public abstract void Saludar();

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"--- Información del Miembro ---");
            Console.WriteLine($"Nombre: {Nombre}, ID: {Identificador}");
        }
    }
}
