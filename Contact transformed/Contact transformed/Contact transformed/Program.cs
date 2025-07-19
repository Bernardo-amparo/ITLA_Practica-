using System;
using System.Collections.Generic;
using System.Linq;

class Contacto
{
    public int Id { get; private set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public int Edad { get; set; }
    public bool EsMejorAmigo { get; set; }

    private static int contador = 1;

    public Contacto()
    {
        Id = contador++;
    }

    public void Mostrar()
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nombre: {Nombre} {Apellido}");
        Console.WriteLine($"Dirección: {Direccion}");
        Console.WriteLine($"Teléfono: {Telefono}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine($"Mejor amigo: {(EsMejorAmigo ? "Sí" : "No")}");
        Console.WriteLine("----------------------------");
    }
}

class Agenda
{
    private List<Contacto> contactos = new List<Contacto>();

    public void MostrarMenu()
    {
        bool ejecutando = true;

        while (ejecutando)
        {
            Console.WriteLine("\n   Mi agenda personal   ");
            Console.WriteLine("   ------------");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Ver contactos");
            Console.WriteLine("3. Buscar contacto");
            Console.WriteLine("4. Modificar contacto");
            Console.WriteLine("5. Eliminar contacto");
            Console.WriteLine("6. Salir");
            Console.WriteLine("=========================");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1": Agregar(); break;
                case "2": Ver(); break;
                case "3": Buscar(); break;
                case "4": Modificar(); break;
                case "5": Eliminar(); break;
                case "6":
                    ejecutando = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    public void Agregar()
    {
        var c = new Contacto();

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
        Console.WriteLine("Contacto agregado correctamente.");
    }

    public void Ver()
    {
        if (!contactos.Any())
        {
            Console.WriteLine("No hay contactos.");
            return;
        }

        foreach (var c in contactos)
            c.Mostrar();
    }

    public void Buscar()
    {
        Console.Write("Buscar por nombre o apellido: ");
        string termino = Console.ReadLine().ToLower();

        var encontrados = contactos
            .Where(c => c.Nombre.ToLower().Contains(termino) || c.Apellido.ToLower().Contains(termino))
            .ToList();

        if (!encontrados.Any())
        {
            Console.WriteLine("No se encontraron contactos.");
            return;
        }

        foreach (var c in encontrados)
            c.Mostrar();
    }

    public void Modificar()
    {
        Console.Write("Ingrese el ID del contacto a modificar: ");
        int id = int.Parse(Console.ReadLine());

        var contacto = contactos.FirstOrDefault(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("Contacto no encontrado.");
            return;
        }

        Console.WriteLine("Deje en blanco para mantener el valor actual.");

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

        Console.WriteLine("Contacto modificado correctamente.");
    }

    public void Eliminar()
    {
        Console.Write("Ingrese el ID del contacto a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        var contacto = contactos.FirstOrDefault(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("Contacto no encontrado.");
            return;
        }

        contactos.Remove(contacto);
        Console.WriteLine("Contacto eliminado correctamente.");
    }
}

class Program
{
    static void Main()
    {
        Agenda agenda = new Agenda();
        agenda.MostrarMenu();
    }
}
