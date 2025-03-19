using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la cantidad de números a ordenar:");
        int n = int.Parse(Console.ReadLine());

        int[] numeros = new int[n];
        Console.WriteLine("Ingrese los números:");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

        // Método Burbuja
        for (int i = 0; i < numeros.Length - 1; i++)
        {
            for (int j = 0; j < numeros.Length - i - 1; j++)
            {
                if (numeros[j] > numeros[j + 1])
                {
                    // Intercambiar
                    int temp = numeros[j];
                    numeros[j] = numeros[j + 1];
                    numeros[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Números ordenados de menor a mayor:");
        foreach (int num in numeros)
        {
            Console.WriteLine(num);
        }
    }
}