using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "nombres.txt";

        // Solicitar al usuario ingresar 5 nombres
        Console.WriteLine("Por favor, ingresa 5 nombres:");
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Nombre {i + 1}: ");
                string nombre = Console.ReadLine();
                writer.WriteLine(nombre);
            }
        }

        // Leer y mostrar los nombres almacenados en el archivo
        Console.WriteLine("\nLos nombres almacenados en el archivo son:");
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}