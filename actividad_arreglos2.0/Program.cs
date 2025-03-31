using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numeros = new int[10];
        int suma = 0;

        Console.WriteLine("Ingrese 10 números enteros:");

        for (int i = 0; i < numeros.Length; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros[i] = int.Parse(Console.ReadLine());
            suma += numeros[i];
        }

        double promedio = (double)suma / numeros.Length;

        Console.WriteLine($"\nLa suma total de los valores es: {suma}");
        Console.WriteLine($"El promedio de los números ingresados es: {promedio:F2}");
    }
}