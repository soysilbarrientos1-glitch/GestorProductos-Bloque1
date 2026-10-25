using System;
using System.Collections.Generic;

namespace GestorProductos
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductoRepository repo = new ProductoRepository();

            Console.WriteLine("--- GESTOR DE PRODUCTOS (Semipermanentes by Marie) ---\n");

            Console.WriteLine("1. Listado completo de productos:");
            ImprimirProductos(repo.ObtenerTodos());

            Console.WriteLine("\n2. Buscar producto por ID (Ejemplo: ID 2):");
            Producto productoBuscado = repo.ObtenerPorId(2);
            if (productoBuscado != null)
            {
                Console.WriteLine($"Encontrado: {productoBuscado.Nombre} - ${productoBuscado.Precio}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }

            Console.WriteLine("\n3. Filtrar por categoría 'Esmaltes':");
            ImprimirProductos(repo.BuscarPorCategoria("Esmaltes"));

            Console.WriteLine("\n4. Agregando nuevo producto...");
            Producto nuevoProducto = new Producto
            {
                Nombre = "Removedor de Semipermanente",
                Precio = 4500,
                Categoria = "Líquidos",
                Activo = true
            };
            repo.Agregar(nuevoProducto);
            Console.WriteLine("¡Producto agregado con éxito!");

            Console.WriteLine("\n5. Listado final (con el nuevo producto):");
            ImprimirProductos(repo.ObtenerTodos());

            Console.ReadLine();
        }

        static void ImprimirProductos(List<Producto> productos)
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos para mostrar.");
                return;
            }

            foreach (var p in productos)
            {
                string estado = p.Activo ? "Activo" : "Inactivo";
                Console.WriteLine($"[ID: {p.Id}] {p.Nombre} | Cat: {p.Categoria} | ${p.Precio} | Estado: {estado}");
            }
        }
    }
}
