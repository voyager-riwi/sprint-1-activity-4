using System;

namespace Sprint2Activity1
{
    public class Producto
    {
        // Propiedades
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CantidadStock { get; set; }

        // Constructor
        public Producto(string nombre, decimal precio, int cantidadStock)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(nombre));
            
            if (precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a cero.", nameof(precio));
            
            if (cantidadStock < 0)
                throw new ArgumentException("La cantidad en stock no puede ser negativa.", nameof(cantidadStock));

            Nombre = nombre.Trim();
            Precio = precio;
            CantidadStock = cantidadStock;
        }

        // Método para consultar los detalles del producto
        public void ConsultarDetalles()
        {
            Console.WriteLine($"Detalles del Producto:");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Precio: ${Precio:F2}");
            Console.WriteLine($"Cantidad en Stock: {CantidadStock}");
        }

        // Método para vender un producto
        public bool Vender(int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad a vender debe ser mayor a cero.", nameof(cantidad));
            }

            if (cantidad > CantidadStock)
            {
                throw new InvalidOperationException($"No hay suficiente stock. Disponible: {CantidadStock}, solicitado: {cantidad}");
            }

            if (cantidad > 1000) // Límite de seguridad para ventas masivas
            {
                throw new ArgumentException("La cantidad a vender excede el límite máximo permitido (1000 unidades).", nameof(cantidad));
            }

            CantidadStock -= cantidad;
            decimal totalVenta = Precio * cantidad;
            Console.WriteLine($"Venta exitosa:");
            Console.WriteLine($"Producto: {Nombre}");
            Console.WriteLine($"Cantidad vendida: {cantidad}");
            Console.WriteLine($"Total: ${totalVenta:F2}");
            Console.WriteLine($"Stock restante: {CantidadStock}");
            return true;
        }

        // Método estático para registrar un nuevo producto
        public static Producto RegistrarProducto(string nombre, decimal precio, int cantidadStock)
        {
            return new Producto(nombre, precio, cantidadStock);
        }
    }
}
