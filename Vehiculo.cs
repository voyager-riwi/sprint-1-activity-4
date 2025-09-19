using System;

namespace Sprint2Activity1
{
    public class Vehiculo
    {
        // Propiedades
        public string Placa { get; set; }
        public string Marca { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSalida { get; set; }

        // Constructor
        public Vehiculo(string placa, string marca)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(placa))
                throw new ArgumentException("La placa del vehículo no puede estar vacía.", nameof(placa));
            
            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("La marca del vehículo no puede estar vacía.", nameof(marca));
            
            // Validar formato básico de placa (al menos 3 caracteres)
            if (placa.Trim().Length < 3)
                throw new ArgumentException("La placa debe tener al menos 3 caracteres.", nameof(placa));

            Placa = placa.Trim().ToUpper();
            Marca = marca.Trim();
            HoraEntrada = DateTime.Now;
            HoraSalida = null;
        }

        // Método para registrar la entrada de un vehículo
        public void RegistrarEntrada()
        {
            HoraEntrada = DateTime.Now;
            HoraSalida = null;
            Console.WriteLine($"Vehículo {Marca} con placa {Placa} registrado a las {HoraEntrada:HH:mm:ss}");
        }

        // Método para registrar la salida de un vehículo
        public void RegistrarSalida()
        {
            HoraSalida = DateTime.Now;
            Console.WriteLine($"Vehículo {Marca} con placa {Placa} salió a las {HoraSalida:HH:mm:ss}");
        }

        // Método para calcular el costo según el tiempo de uso
        public decimal CalcularCosto(decimal costoPorHora = 2.50m)
        {
            if (HoraSalida == null)
            {
                throw new InvalidOperationException("El vehículo aún no ha salido del parqueadero.");
            }

            if (costoPorHora <= 0)
            {
                throw new ArgumentException("El costo por hora debe ser mayor a cero.", nameof(costoPorHora));
            }

            if (costoPorHora > 100) // Límite razonable para costo por hora
            {
                throw new ArgumentException("El costo por hora excede el límite máximo permitido ($100).", nameof(costoPorHora));
            }

            TimeSpan tiempoEstacionado = HoraSalida.Value - HoraEntrada;
            
            // Validar que la hora de salida sea posterior a la de entrada
            if (tiempoEstacionado.TotalMinutes < 0)
            {
                throw new InvalidOperationException("La hora de salida no puede ser anterior a la hora de entrada.");
            }

            double horas = tiempoEstacionado.TotalHours;
            
            // Redondear hacia arriba para cobrar por horas completas
            int horasACobrar = (int)Math.Ceiling(horas);
            
            decimal costoTotal = horasACobrar * costoPorHora;
            
            Console.WriteLine($"Cálculo de Costo:");
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Hora de entrada: {HoraEntrada:HH:mm:ss}");
            Console.WriteLine($"Hora de salida: {HoraSalida:HH:mm:ss}");
            Console.WriteLine($"Tiempo estacionado: {tiempoEstacionado.ToString(@"hh\:mm\:ss")}");
            Console.WriteLine($"Horas a cobrar: {horasACobrar}");
            Console.WriteLine($"Costo por hora: ${costoPorHora:F2}");
            Console.WriteLine($"Total a pagar: ${costoTotal:F2}");
            
            return costoTotal;
        }

        // Método estático para registrar la entrada de un vehículo
        public static Vehiculo RegistrarEntradaVehiculo(string placa, string marca)
        {
            return new Vehiculo(placa, marca);
        }
    }
}
