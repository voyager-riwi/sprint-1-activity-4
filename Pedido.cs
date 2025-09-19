using System;
using System.Collections.Generic;

namespace Sprint2Activity1
{
    public class Plato
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Plato(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }

    public class Pedido
    {
        // Propiedades
        public int NumeroMesa { get; set; }
        public List<Plato> Platos { get; set; }

        // Constructor
        public Pedido(int numeroMesa)
        {
            NumeroMesa = numeroMesa;
            Platos = new List<Plato>();
        }

        // Método para agregar un plato al pedido
        public void AgregarPlato(string nombrePlato, decimal precio)
        {
            if (string.IsNullOrWhiteSpace(nombrePlato))
                throw new ArgumentException("El nombre del plato no puede estar vacío.", nameof(nombrePlato));
            
            if (precio <= 0)
                throw new ArgumentException("El precio del plato debe ser mayor a cero.", nameof(precio));
            
            if (precio > 1000) // Límite razonable para precio de un plato
                throw new ArgumentException("El precio del plato excede el límite máximo permitido ($1,000).", nameof(precio));
            
            if (Platos.Count >= 20) // Límite razonable de platos por pedido
                throw new InvalidOperationException("No se pueden agregar más de 20 platos a un pedido.");

            Platos.Add(new Plato(nombrePlato.Trim(), precio));
            Console.WriteLine($"Plato '{nombrePlato}' agregado al pedido de la mesa {NumeroMesa}");
        }

        // Método para calcular el total del pedido
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var plato in Platos)
            {
                total += plato.Precio;
            }
            return total;
        }

        // Método para mostrar la información de los platos del pedido
        public void MostrarInformacionPlatos()
        {
            Console.WriteLine($"Pedido de la Mesa {NumeroMesa}:");
            if (Platos.Count == 0)
            {
                Console.WriteLine("No hay platos en este pedido.");
            }
            else
            {
                Console.WriteLine("Platos:");
                for (int i = 0; i < Platos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Platos[i].Nombre} - ${Platos[i].Precio:F2}");
                }
                Console.WriteLine($"Total: ${CalcularTotal():F2}");
            }
        }

        // Método estático para registrar un nuevo pedido
        public static Pedido RegistrarPedido(int numeroMesa)
        {
            return new Pedido(numeroMesa);
        }
    }
}
