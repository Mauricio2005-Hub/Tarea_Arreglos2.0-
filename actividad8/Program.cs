using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Solicitar al usuario que ingrese 10 números
        int[] numeros = new int[10];
        Console.WriteLine("Ingrese 10 números:");
        for (int i = 0; i < numeros.Length; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

        // Mostrar el arreglo original
        Console.WriteLine("\nArreglo original:");
        Console.WriteLine(string.Join(", ", numeros));

        // Solicitar el número a eliminar
        Console.Write("\nIngrese el número que desea eliminar: ");
        int numeroAEliminar = int.Parse(Console.ReadLine());

        // Eliminar el número del arreglo
        int[] nuevoArreglo = numeros.Where(n => n != numeroAEliminar).ToArray();

        // Mostrar el nuevo arreglo
        Console.WriteLine("\nArreglo después de eliminar el número:");
        Console.WriteLine(string.Join(", ", nuevoArreglo));
    }
}