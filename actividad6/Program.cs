using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "notas.txt";

        // Step 1: Input student data and save to file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            Console.WriteLine("Ingrese los datos de los estudiantes (nombre y 3 calificaciones).");
            Console.WriteLine("Escriba 'fin' como nombre para terminar.");

            while (true)
            {
                Console.Write("Nombre del estudiante: ");
                string nombre = Console.ReadLine();
                if (nombre.ToLower() == "fin") break;

                Console.Write("Calificación 1: ");
                double calificacion1 = double.Parse(Console.ReadLine());

                Console.Write("Calificación 2: ");
                double calificacion2 = double.Parse(Console.ReadLine());

                Console.Write("Calificación 3: ");
                double calificacion3 = double.Parse(Console.ReadLine());

                writer.WriteLine($"{nombre},{calificacion1},{calificacion2},{calificacion3}");
            }
        }

        // Step 2: Read file and calculate averages
        Console.WriteLine("\nPromedios de los estudiantes:");
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    string nombre = data[0];
                    double calificacion1 = double.Parse(data[1]);
                    double calificacion2 = double.Parse(data[2]);
                    double calificacion3 = double.Parse(data[3]);

                    double promedio = (calificacion1 + calificacion2 + calificacion3) / 3;
                    Console.WriteLine($"Estudiante: {nombre}, Promedio: {promedio:F2}");
                }
            }
        }
        else
        {
            Console.WriteLine("El archivo de notas no existe.");
        }
    }
}