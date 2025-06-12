using System;
using System.IO; 

namespace CalculadoraV3_SumaRestaMulti
{
    class Program
    {
        private static readonly string LogFilePath = "registro_operaciones_v3.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" Calculadora V3: Suma, Resta, Multi");
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

                Console.Write("\nIngrese el primer numero (o 'salir' para terminar): ");
                string input1 = Console.ReadLine();
                if (input1.ToLower() == "salir")
                {
                    break;
                }
                num1 = Convert.ToDecimal(input1); 

                Console.Write("Ingrese la operacion (+, -, *): "); 
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
                    default:
                        Console.WriteLine("Operacion no reconocida. Solo '+', '-' y '*'.");
                        logEntry = $"{DateTime.Now}: ERROR - Operacion no reconocida: {num1} {operacion} {num2}";
                        break;
                }

                if (string.IsNullOrEmpty(logEntry)) 
                {
                    Console.WriteLine($"El resultado de {num1} {operacion} {num2} es: {resultado}");
                    logEntry = $"{DateTime.Now}: {num1} {operacion} {num2} = {resultado}";
                }

                File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
            }

            Console.WriteLine("\nCalculadora V3 terminada. Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}