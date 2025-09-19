using System;

namespace Sprint2Activity1
{
    public class CitaMedica
    {
        // Propiedades
        public string NombrePaciente { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaCita { get; set; }

        // Constructor
        public CitaMedica(string nombrePaciente, string especialidad, DateTime fechaCita)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(nombrePaciente))
                throw new ArgumentException("El nombre del paciente no puede estar vacío.", nameof(nombrePaciente));
            
            if (string.IsNullOrWhiteSpace(especialidad))
                throw new ArgumentException("La especialidad no puede estar vacía.", nameof(especialidad));
            
            if (fechaCita < DateTime.Now.Date)
                throw new ArgumentException("La fecha de la cita no puede ser anterior a hoy.", nameof(fechaCita));
            
            if (fechaCita > DateTime.Now.AddYears(2)) // Límite razonable para citas futuras
                throw new ArgumentException("La fecha de la cita no puede ser más de 2 años en el futuro.", nameof(fechaCita));

            NombrePaciente = nombrePaciente.Trim();
            Especialidad = especialidad.Trim();
            FechaCita = fechaCita;
        }

        // Método para consultar los datos de la cita
        public void ConsultarDatos()
        {
            Console.WriteLine($"Datos de la Cita Médica:");
            Console.WriteLine($"Paciente: {NombrePaciente}");
            Console.WriteLine($"Especialidad: {Especialidad}");
            Console.WriteLine($"Fecha de la cita: {FechaCita:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Días restantes: {CalcularDiasRestantes()}");
        }

        // Método para calcular cuántos días faltan para la cita
        public int CalcularDiasRestantes()
        {
            DateTime hoy = DateTime.Now;
            TimeSpan diferencia = FechaCita.Date - hoy.Date;
            int diasRestantes = (int)diferencia.TotalDays;
            
            // Validar que la fecha de la cita sea válida
            if (FechaCita == DateTime.MinValue)
                throw new InvalidOperationException("La fecha de la cita no ha sido establecida correctamente.");
            
            return diasRestantes;
        }

        // Método para verificar si la cita es próxima (en los próximos 7 días)
        public bool EsCitaProxima()
        {
            return CalcularDiasRestantes() <= 7 && CalcularDiasRestantes() >= 0;
        }

        // Método para verificar si la cita ya pasó
        public bool EsCitaPasada()
        {
            return CalcularDiasRestantes() < 0;
        }

        // Método para obtener el estado de la cita
        public string ObtenerEstadoCita()
        {
            int diasRestantes = CalcularDiasRestantes();
            
            if (diasRestantes < 0)
            {
                return "Cita pasada";
            }
            else if (diasRestantes == 0)
            {
                return "Cita es hoy";
            }
            else if (diasRestantes <= 7)
            {
                return "Cita próxima";
            }
            else
            {
                return "Cita futura";
            }
        }

        // Método para mostrar información detallada de la cita
        public void MostrarInformacionDetallada()
        {
            Console.WriteLine($"Información Detallada de la Cita:");
            Console.WriteLine($"Paciente: {NombrePaciente}");
            Console.WriteLine($"Especialidad: {Especialidad}");
            Console.WriteLine($"Fecha: {FechaCita:dddd, dd 'de' MMMM 'de' yyyy}");
            Console.WriteLine($"Hora: {FechaCita:HH:mm}");
            Console.WriteLine($"Días restantes: {CalcularDiasRestantes()}");
            Console.WriteLine($"Estado: {ObtenerEstadoCita()}");
        }

        // Método estático para registrar una nueva cita
        public static CitaMedica RegistrarCita(string nombrePaciente, string especialidad, DateTime fechaCita)
        {
            return new CitaMedica(nombrePaciente, especialidad, fechaCita);
        }
    }
}
