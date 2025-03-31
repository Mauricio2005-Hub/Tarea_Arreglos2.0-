using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "ventas.csv";

        // Registrar ventas
        using (StreamWriter writer = new StreamWriter(filePath, append: false))
        {
            Console.WriteLine("Registro de Ventas (Escribe 'fin' para terminar):");
            while (true)
            {
                Console.Write("Nombre del producto: ");
                string producto = Console.ReadLine();
                if (producto.ToLower() == "fin") break;

                Console.Write("Cantidad vendida: ");
                if (!int.TryParse(Console.ReadLine(), out int cantidad))
                {
                    Console.WriteLine("Cantidad inválida. Inténtalo de nuevo.");
                    continue;
                }

                Console.Write("Precio unitario: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
                {
                    Console.WriteLine("Precio inválido. Inténtalo de nuevo.");
                    continue;
                }

                writer.WriteLine($"{producto},{cantidad},{precio}");
            }
        }

        // Leer archivo y calcular total de ventas
        if (File.Exists(filePath))
        {
            decimal totalVentas = 0;
            Console.WriteLine("\nVentas registradas:");
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] datos = line.Split(',');
                    string producto = datos[0];
                    int cantidad = int.Parse(datos[1]);
                    decimal precio = decimal.Parse(datos[2]);

                    decimal subtotal = cantidad * precio;
                    totalVentas += subtotal;

                    Console.WriteLine($"Producto: {producto}, Cantidad: {cantidad}, Precio Unitario: {precio:C}, Subtotal: {subtotal:C}");
                }
            }
            Console.WriteLine($"\nTotal de ventas del día: {totalVentas:C}");
        }
        else
        {
            Console.WriteLine("No se encontró el archivo de ventas.");
        }
    }
}