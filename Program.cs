using System;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Producto
{
    private string id;
    private string nombre;
    private int cantidad;
    private decimal precio;

    public Producto(string id, string nombre, int cantidad, decimal precio)
    {
        this.id = id;
        this.nombre = nombre;
        this.cantidad = cantidad;
        this.precio = precio;
    }

    // Getters y Setters
    public string Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }
    public decimal Precio { get => precio; set => precio = value; }

    public void MostrarInformacion()
    {
        Console.WriteLine($"{id}, {nombre}, {cantidad}, ${precio}");
    }
}

class Program
{
    private static Producto[] productos = new Producto[20];
    private static int contador = 0;
    private static string archivoJson = "productos.json";

    static void Main(string[] args)
    {
        CargarProductos();
        int opcion;
        do
        {
            MostrarMenu();
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarProducto();
                    break;
                case 2:
                    BuscarProducto();
                    break;
                case 3:
                    MostrarProductos();
                    break;
                case 4:
                    EncontrarProductoMasCaro();
                    break;
                case 5:
                    GuardarProductos();
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        } while (opcion != 5);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Agregar nuevo producto");
        Console.WriteLine("2. Buscar producto por nombre");
        Console.WriteLine("3. Mostrar todos los productos");
        Console.WriteLine("4. Encontrar producto más caro");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void AgregarProducto()
    {
        if (contador >= 20)
        {
            Console.WriteLine("No se pueden agregar más productos. Límite alcanzado.");
            return;
        }

        Console.Write("ID: ");
        string id = Console.ReadLine();
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Cantidad: ");
        int cantidad = int.Parse(Console.ReadLine());
        Console.Write("Precio: $");
        decimal precio = decimal.Parse(Console.ReadLine());

        productos[contador] = new Producto(id, nombre, cantidad, precio);
        contador++;
        Console.WriteLine("Producto agregado exitosamente.");
    }

    static void BuscarProducto()
    {
        Console.Write("Ingrese el nombre del producto a buscar: ");
        string nombre = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < contador; i++)
        {
            if (productos[i].Nombre.ToLower() == nombre.ToLower())
            {
                productos[i].MostrarInformacion();
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
            Console.WriteLine("Producto no encontrado.");
    }

    static void MostrarProductos()
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay productos registrados.");
            return;
        }

        for (int i = 0; i < contador; i++)
        {
            productos[i].MostrarInformacion();
        }
    }

    static void EncontrarProductoMasCaro()
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay productos registrados.");
            return;
        }

        Producto masCaro = EncontrarMasCaro(0);
        Console.WriteLine("El producto más caro es:");
        masCaro.MostrarInformacion();
    }

    static Producto EncontrarMasCaro(int indice)
    {
        if (indice == contador - 1)
            return productos[indice];

        Producto restante = EncontrarMasCaro(indice + 1);
        return productos[indice].Precio > restante.Precio ? productos[indice] : restante;
    }

    static void CargarProductos()
    {
        if (File.Exists(archivoJson))
        {
            string jsonString = File.ReadAllText(archivoJson);
            var productosTemp = JsonSerializer.Deserialize<List<Producto>>(jsonString);
            contador = Math.Min(productosTemp.Count, 20);
            for (int i = 0; i < contador; i++)
            {
                productos[i] = productosTemp[i];
            }
        }
    }

    static void GuardarProductos()
    {
        var productosActivos = productos.Take(contador).ToList();
        string jsonString = JsonSerializer.Serialize(productosActivos);
        File.WriteAllText(archivoJson, jsonString);
    }
}