using System;

namespace Sprint2Activity1
{
    public class Reserva
    {
        // Propiedades
        public int NumeroHabitacion { get; set; }
        public string NombreHuesped { get; set; }
        public int CantidadNoches { get; set; }
        public decimal ValorPorNoche { get; set; }

        // Constructor
        public Reserva(int numeroHabitacion, string nombreHuesped, int cantidadNoches, decimal valorPorNoche = 50.00m)
        {
            // Validaciones
            if (numeroHabitacion <= 0)
                throw new ArgumentException("El número de habitación debe ser mayor a cero.", nameof(numeroHabitacion));
            
            if (string.IsNullOrWhiteSpace(nombreHuesped))
                throw new ArgumentException("El nombre del huésped no puede estar vacío.", nameof(nombreHuesped));
            
            if (cantidadNoches <= 0)
                throw new ArgumentException("La cantidad de noches debe ser mayor a cero.", nameof(cantidadNoches));
            
            if (cantidadNoches > 365) // Límite razonable para una reserva
                throw new ArgumentException("La cantidad de noches excede el límite máximo permitido (365).", nameof(cantidadNoches));
            
            if (valorPorNoche <= 0)
                throw new ArgumentException("El valor por noche debe ser mayor a cero.", nameof(valorPorNoche));
            
            if (valorPorNoche > 10000) // Límite razonable para precio por noche
                throw new ArgumentException("El valor por noche excede el límite máximo permitido ($10,000).", nameof(valorPorNoche));

            NumeroHabitacion = numeroHabitacion;
            NombreHuesped = nombreHuesped.Trim();
            CantidadNoches = cantidadNoches;
            ValorPorNoche = valorPorNoche;
        }

        // Método para consultar la información de la reserva
        public void ConsultarInformacion()
        {
            Console.WriteLine($"Información de la Reserva:");
            Console.WriteLine($"Número de habitación: {NumeroHabitacion}");
            Console.WriteLine($"Huésped: {NombreHuesped}");
            Console.WriteLine($"Cantidad de noches: {CantidadNoches}");
            Console.WriteLine($"Valor por noche: ${ValorPorNoche:F2}");
            Console.WriteLine($"Costo total: ${CalcularCostoTotal():F2}");
        }

        // Método para calcular el costo total de la estadía
        public decimal CalcularCostoTotal()
        {
            return CantidadNoches * ValorPorNoche;
        }

        // Método para calcular el costo con descuentos
        public decimal CalcularCostoConDescuento()
        {
            decimal costoBase = CalcularCostoTotal();
            decimal descuento = 0;

            // Descuento por estadía larga (más de 7 noches)
            if (CantidadNoches > 7)
            {
                descuento = costoBase * 0.10m; // 10% de descuento
            }
            // Descuento por estadía media (más de 3 noches)
            else if (CantidadNoches > 3)
            {
                descuento = costoBase * 0.05m; // 5% de descuento
            }

            decimal costoFinal = costoBase - descuento;
            
            if (descuento > 0)
            {
                Console.WriteLine($"Descuento aplicado: ${descuento:F2}");
            }
            
            return costoFinal;
        }

        // Método para obtener información de descuentos
        public void MostrarInformacionDescuentos()
        {
            Console.WriteLine($"Información de Descuentos:");
            Console.WriteLine($"Costo base: ${CalcularCostoTotal():F2}");
            
            if (CantidadNoches > 7)
            {
                Console.WriteLine("Descuento aplicado: 10% (estadía larga - más de 7 noches)");
            }
            else if (CantidadNoches > 3)
            {
                Console.WriteLine("Descuento aplicado: 5% (estadía media - más de 3 noches)");
            }
            else
            {
                Console.WriteLine("No hay descuentos aplicables");
            }
            
            Console.WriteLine($"Costo final: ${CalcularCostoConDescuento():F2}");
        }

        // Método estático para registrar una nueva reserva
        public static Reserva RegistrarReserva(int numeroHabitacion, string nombreHuesped, int cantidadNoches, decimal valorPorNoche = 50.00m)
        {
            return new Reserva(numeroHabitacion, nombreHuesped, cantidadNoches, valorPorNoche);
        }
    }
}
