using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiembroDeLaComunidad
{
    public class Estudiante : Miembrosbase
    {
        public string Carrera { get; set; }

        public Estudiante(string nombre, int id, string carrera) : base(nombre, id)
        {
            Carrera = carrera;
        }

        public override void Saludar() 
        {
            Console.WriteLine($"Hola, soy el Estudiante {Nombre} de la carrera de {Carrera}.");
        }
    }

    public class ExAlumno : Miembrosbase
    {
        public int AnioGraduacion { get; set; }

        public ExAlumno(string nombre, int id, int anio) : base(nombre, id)
        {
            AnioGraduacion = anio;
        }

        public override void Saludar()
        {
            Console.WriteLine($"Saludos, soy {Nombre}, me gradué en el año {AnioGraduacion}.");
        }
    }

    public abstract class Empleado : Miembrosbase
    {
        public decimal Salario { get; set; }

        public Empleado(string nombre, int id, decimal salario) : base (nombre, id)
        {
            Salario = salario;
        }

        public abstract void Trabajar();

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Salario: {Salario:C}");
        }
    }
}
