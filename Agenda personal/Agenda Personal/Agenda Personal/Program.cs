using System;
using System.Collections.Generic;
using System.Linq;

class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public int Edad { get; set; }
    public bool EsMejorAmigo { get; set; }
}

class Program
{
    static List<Contacto> contactos = new List<Contacto>();
    static int siguienteId = 1;

    static void Main()
    {
        bool ejecutando = true;

        while (ejecutando)
        {
            MostrarMenu();
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    AgregarContacto();
                    break;
                case "2":
                    VerContactos();
                    break;
                case "3":
                    BuscarContacto();
                    break;
                case "4":
                    ModificarContacto();
                    break;
                case "5":
                    EliminarContacto();
                    break;
                case "6":
                    ejecutando = false;
                    Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción inválida.\n");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("   Mi agenda personal  ");
        Console.WriteLine("     ------------");
        Console.WriteLine("1. Agregar contacto");
        Console.WriteLine("2. Ver contactos");
        Console.WriteLine("3. Buscar contacto");
        Console.WriteLine("4. Modificar contacto");
        Console.WriteLine("5. Eliminar contacto");
        Console.WriteLine("6. Salir");
        Console.WriteLine("=========================");
    }

    static void AgregarContacto()
    {
        Contacto c = new Contacto();
        c.Id = siguienteId++;

        Console.Write("Nombre: ");
        c.Nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        c.Apellido = Console.ReadLine();

        Console.Write("Dirección: ");
        c.Direccion = Console.ReadLine();

        Console.Write("Teléfono: ");
        c.Telefono = Console.ReadLine();

        Console.Write("Email: ");
        c.Email = Console.ReadLine();

        Console.Write("Edad: ");
        c.Edad = int.Parse(Console.ReadLine());

        Console.Write("¿Es mejor amigo? (1 = Sí, 2 = No): ");
        c.EsMejorAmigo = Console.ReadLine() == "1";

        contactos.Add(c);
        Console.WriteLine("Contacto agregado exitosamente.\n");
    }

    static void VerContactos()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("No hay contactos.\n");
            return;
        }

        Console.WriteLine("Lista de contactos:");
        foreach (var c in contactos)
        {
            MostrarContacto(c);
        }
    }

    static void BuscarContacto()
    {
        Console.Write("Buscar por nombre o apellido: ");
        string termino = Console.ReadLine().ToLower();

        var resultados = contactos
            .Where(c => c.Nombre.ToLower().Contains(termino) || c.Apellido.ToLower().Contains(termino))
            .ToList();

        if (resultados.Count == 0)
        {
            Console.WriteLine("No se encontraron coincidencias.\n");
            return;
        }

        Console.WriteLine("Resultados encontrados:");
        foreach (var c in resultados)
        {
            MostrarContacto(c);
        }
    }

    static void ModificarContacto()
    {
        Console.Write("Ingrese el ID del contacto a modificar: ");
        int id = int.Parse(Console.ReadLine());

        var contacto = contactos.FirstOrDefault(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("Contacto no encontrado.\n");
            return;
        }

        Console.WriteLine("Deje en blanco si no desea cambiar un campo.");

        Console.Write($"Nombre ({contacto.Nombre}): ");
        string input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) contacto.Nombre = input;

        Console.Write($"Apellido ({contacto.Apellido}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) contacto.Apellido = input;

        Console.Write($"Dirección ({contacto.Direccion}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) contacto.Direccion = input;

        Console.Write($"Teléfono ({contacto.Telefono}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) contacto.Telefono = input;

        Console.Write($"Email ({contacto.Email}): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) contacto.Email = input;

        Console.Write($"Edad ({contacto.Edad}): ");
        input = Console.ReadLine();
        if (int.TryParse(input, out int nuevaEdad)) contacto.Edad = nuevaEdad;

        Console.Write($"¿Es mejor amigo? (1 = Sí, 2 = No) (Actual: {(contacto.EsMejorAmigo ? "Sí" : "No")}): ");
        input = Console.ReadLine();
        if (input == "1") contacto.EsMejorAmigo = true;
        else if (input == "2") contacto.EsMejorAmigo = false;

        Console.WriteLine("Contacto modificado correctamente.\n");
    }

    static void EliminarContacto()
    {
        Console.Write("Ingrese el ID del contacto a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        var contacto = contactos.FirstOrDefault(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("Contacto no encontrado.\n");
            return;
        }

        contactos.Remove(contacto);
        Console.WriteLine("Contacto eliminado exitosamente.\n");
    }

    static void MostrarContacto(Contacto c)
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine($"ID: {c.Id}");
        Console.WriteLine($"Nombre: {c.Nombre} {c.Apellido}");
        Console.WriteLine($"Dirección: {c.Direccion}");
        Console.WriteLine($"Teléfono: {c.Telefono}");
        Console.WriteLine($"Email: {c.Email}");
        Console.WriteLine($"Edad: {c.Edad}");
        Console.WriteLine($"Mejor amigo: {(c.EsMejorAmigo ? "Sí" : "No")}");
        Console.WriteLine("----------------------------");
    }
}
