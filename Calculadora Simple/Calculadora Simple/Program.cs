// See https://aka.ms/new-console-template for more information
using System;

decimal num1 ;
decimal num2 ; 
decimal result ;
string capturedValue;
Console.WriteLine("This is the best caculator");

Console.WriteLine("Please Type the first number");
num1 = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Please Type the secons number");
num2 = Convert.ToDecimal(Console.ReadLine());

result = num1 + num2;

Console.WriteLine($"The Result of operation is: {result}");