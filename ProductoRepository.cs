using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorProductos
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly List<Producto> _productos;

        public ProductoRepository()
        {
            _productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Kit Semipermanente Básico", Precio = 15000, Categoria = "Kits", Activo = true },
                new Producto { Id = 2, Nombre = "Lámpara UV/LED 48W", Precio = 25000, Categoria = "Equipos", Activo = true },
                new Producto { Id = 3, Nombre = "Esmalte Rojo Rubí", Precio = 3500, Categoria = "Esmaltes", Activo = true },
                new Producto { Id = 4, Nombre = "Aceite para Cutículas", Precio = 2000, Categoria = "Tratamiento", Activo = false }
            };
        }

        public void Agregar(Producto producto)
        {
            producto.Id = _productos.Max(p => p.Id) + 1;
            _productos.Add(producto);
        }

        public List<Producto> ObtenerTodos()
        {
            return _productos.ToList();
        }

        public Producto ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public List<Producto> BuscarPorCategoria(string categoria)
        {
            return _productos.Where(p => p.Categoria.ToLower() == categoria.ToLower()).ToList();
        }
    }
}
