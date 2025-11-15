using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiembroDeLaComunidad
{
    public class Administrativo : Empleado
    {
        public string Departamento { get; set; }

        public Administrativo(string nombre, int id, decimal salario, string depto) : base(nombre, id, salario)
        {
            Departamento = depto;
        }

        public override void Saludar()
        {
            Console.WriteLine($"Buenos días, soy el personal Administrativo {Nombre} del departamento de {Departamento}.");
        }

        public override void Trabajar()
        {
            Console.WriteLine($"{Nombre} está realizando tareas administrativas.");
        }
    }

    public abstract class Docente : Empleado
    {
        public string AreaDeEspecialidad { get; set; }

        public Docente(string nombre, int id, decimal salario, string area) : base(nombre, id, salario)
        {
            AreaDeEspecialidad = area;
        }

        public void Ensenar()
        {
            Console.WriteLine($"{Nombre} está enseñando sobre {AreaDeEspecialidad}.");
        }

    }
}