using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] matriz = new int[3, 3];

        // Solicitar al usuario que ingrese los valores de la matriz
        Console.WriteLine("Ingrese los valores de la matriz 3x3:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Elemento [{i},{j}]: ");
                matriz[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Solicitar al usuario que ingrese el número para multiplicar cada fila
        int[] multiplicadores = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Ingrese el número para multiplicar la fila {i + 1}: ");
            multiplicadores[i] = int.Parse(Console.ReadLine());
        }

        // Multiplicar cada fila por el número correspondiente
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matriz[i, j] *= multiplicadores[i];
            }
        }

        // Mostrar la nueva matriz
        Console.WriteLine("\nLa nueva matriz es:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}