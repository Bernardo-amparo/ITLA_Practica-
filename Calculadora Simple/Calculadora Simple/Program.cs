using System;
using System.IO;

namespace CalculadoraV4_Completa
{
    class Program
    {
        private static readonly string LogFilePath = "registro_operaciones_v4.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" Calculadora V4: Todas Operaciones ");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Operaciones se guardan en: {Path.GetFullPath(LogFilePath)}");
            Console.WriteLine("-----------------------------------");

            if (!File.Exists(LogFilePath))
            {
                File.Create(LogFilePath).Close();
            }

            while (true)
            {
                decimal num1;
                decimal num2;
                string operacion;
                decimal resultado = 0;
                string logEntry = "";
                bool errorEnOperacion = false;

                Console.Write("\nIngrese el primer numero (o 'salir' para terminar): ");
                string input1 = Console.ReadLine();
                if (input1.ToLower() == "salir")
                {
                    break;
                }
                num1 = Convert.ToDecimal(input1);

                Console.Write("Ingrese la operacion (+, -, *, /): ");
                operacion = Console.ReadLine();

                Console.Write("Ingrese el segundo numero: ");
                num2 = Convert.ToDecimal(Console.ReadLine());

                switch (operacion)
                {
                    case "+":
                        resultado = num1 + num2;
                        break;
                    case "-":
                        resultado = num1 - num2;
                        break;
                    case "*":
                        resultado = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            resultado = num1 / num2;
                        }
                        else
                        {
                            Console.WriteLine("¡Error: No se puede dividir por cero!");
                            logEntry = $"{DateTime.Now}: ERROR - Division por cero: {num1} {operacion} {num2}";
                            errorEnOperacion = true;
                        }
                        break;
                    default: 
                        Console.WriteLine("Operacion no reconocida. Solo '+', '-', '*' y '/'.");
                        logEntry = $"{DateTime.Now}: ERROR - Operacion no reconocida: {num1} {operacion} {num2}";
                        errorEnOperacion = true;
                        break;
                }

                if (!errorEnOperacion)
                {
                    Console.WriteLine($"El resultado de {num1} {operacion} {num2} es: {resultado}");
                    logEntry = $"{DateTime.Now}: {num1} {operacion} {num2} = {resultado}";
                }

                File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
            }

            Console.WriteLine("\nCalculadora V4 terminada. Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}