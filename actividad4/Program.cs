using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[5];

        // Solicitar 5 números al usuario
        Console.WriteLine("Por favor, ingresa 5 números enteros:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numbers[i] = int.Parse(Console.ReadLine());
        }

        // Mostrar el arreglo original
        Console.WriteLine("\nArreglo original:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }

        // Mostrar el arreglo invertido
        Console.WriteLine("\n\nArreglo invertido:");
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            Console.Write(numbers[i] + " ");
        }

        Console.WriteLine();
    }
}