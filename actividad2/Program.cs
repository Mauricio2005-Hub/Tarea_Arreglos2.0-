using System;

class Program
{
    static void Main(string[] args)
    {
        // Declarar un arreglo de 5 nombres
        string[] nombres = new string[5];

        // Solicitar al usuario que llene el arreglo
        Console.WriteLine("Por favor, ingresa 5 nombres:");
        for (int i = 0; i < nombres.Length; i++)
        {
            Console.Write($"Nombre {i + 1}: ");
            nombres[i] = Console.ReadLine();
        }

        // Pedir al usuario un nombre a buscar
        Console.Write("Ingresa el nombre que deseas buscar: ");
        string nombreBuscado = Console.ReadLine();

        // Buscar el nombre en el arreglo
        int posicion = Array.IndexOf(nombres, nombreBuscado);

        // Verificar si el nombre fue encontrado
        if (posicion != -1)
        {
            Console.WriteLine($"El nombre '{nombreBuscado}' se encuentra en la posición {posicion} del arreglo.");
        }
        else
        {
            Console.WriteLine($"El nombre '{nombreBuscado}' no se encuentra en el arreglo.");
        }
    }
}