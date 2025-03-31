using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "texto.txt";

        // Solicitar al usuario que escriba un texto
        Console.WriteLine("Escribe un texto:");
        string userInput = Console.ReadLine();

        // Guardar el texto en un archivo
        File.WriteAllText(filePath, userInput);
        Console.WriteLine($"El texto se ha guardado en el archivo '{filePath}'.");

        // Leer el archivo y contar las palabras
        string fileContent = File.ReadAllText(filePath);
        int wordCount = CountWords(fileContent);

        Console.WriteLine($"El archivo contiene {wordCount} palabras.");
    }

    static int CountWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return 0;
        }

        // Dividir el texto en palabras usando espacios como separadores
        string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
}