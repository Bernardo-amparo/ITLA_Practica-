// See https://aka.ms/new-console-template for more information
using MiembroDeLaComunidad;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Demostración de Polimorfismo y Herencia ---");

        Miembrosbase estudiante = new Estudiante("Ana Lopez", 1001, "Ingeniería de Software");
        Miembrosbase exalumno = new ExAlumno("Roberto Diaz", 2002, 2015);
        Miembrosbase administrativo = new Administrativo("Marta Solis", 3003, 35000.00m, "Recursos Humanos");
        Miembrosbase maestro = new Maestro("Carlos Vera", 4004, 50000.00m, "Matemáticas");
        Miembrosbase gerente = new Administrador("Elena Perez", 5005, 75000.00m, "Gestión de Proyectos", "Decana");
        Miembrosbase[] comunidad = { estudiante, exalumno, administrativo, maestro, gerente };

        foreach (var miembro in comunidad)
        {
            miembro.MostrarInformacion();
            miembro.Saludar();        

            if (miembro is Empleado emp)
            {
                emp.Trabajar();
            }

            if (miembro is Docente doc)
            {
                doc.Ensenar();
            }

            Console.WriteLine("------------------------------------------");
        }
    }
}