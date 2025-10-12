using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiembroDeLaComunidad
{
    public class Maestro : Docente
    {
        public Maestro(string nombre, int id, decimal salario, string area) : base(nombre, id, salario, area)
        {
        }

        public override void Saludar()
        {
            Console.WriteLine($"¡Hola! Soy el Maestro {Nombre}, especialista en {AreaDeEspecialidad}.");
        }

        public override void Trabajar()
        {
            Console.WriteLine($"{Nombre} está impartiendo una clase.");
        }
    }

    public class Administrador : Docente
    {
        public string PuestoGerencial { get; set; }

        public Administrador(string nombre, int id, decimal salario, string area, string puesto) : base(nombre, id, salario, area)
        {
            PuestoGerencial = puesto;
        }

        public override void Saludar()
        {
            Console.WriteLine($"Buenas tardes. Soy {Nombre}, {PuestoGerencial} y Docente de {AreaDeEspecialidad}.");
        }

        public override void Trabajar()
        {
            Console.WriteLine($"{Nombre} está realizando tareas administrativas de gestión.");
        }
    }
}
