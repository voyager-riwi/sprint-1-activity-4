using System;

namespace Sprint2Activity1
{
    public class Pelicula
    {
        // Propiedades
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int DuracionMinutos { get; set; }

        // Constructor
        public Pelicula(string titulo, string genero, int duracionMinutos)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("El título de la película no puede estar vacío.", nameof(titulo));
            
            if (string.IsNullOrWhiteSpace(genero))
                throw new ArgumentException("El género de la película no puede estar vacío.", nameof(genero));
            
            if (duracionMinutos <= 0)
                throw new ArgumentException("La duración debe ser mayor a cero minutos.", nameof(duracionMinutos));
            
            if (duracionMinutos > 600) // Límite razonable para una película (10 horas)
                throw new ArgumentException("La duración excede el límite máximo permitido (600 minutos).", nameof(duracionMinutos));

            Titulo = titulo.Trim();
            Genero = genero.Trim();
            DuracionMinutos = duracionMinutos;
        }

        // Método para consultar la información de la película
        public void ConsultarInformacion()
        {
            Console.WriteLine($"Información de la Película:");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Género: {Genero}");
            Console.WriteLine($"Duración: {DuracionMinutos} minutos");
            Console.WriteLine($"¿Es una película larga? {(EsPeliculaLarga() ? "Sí" : "No")}");
        }

        // Método para saber si una película es larga (más de 120 minutos)
        public bool EsPeliculaLarga()
        {
            return DuracionMinutos > 120;
        }

        // Método para convertir duración a horas y minutos
        public string ObtenerDuracionFormateada()
        {
            int horas = DuracionMinutos / 60;
            int minutos = DuracionMinutos % 60;
            
            if (horas > 0)
            {
                return $"{horas}h {minutos}m";
            }
            else
            {
                return $"{minutos}m";
            }
        }

        // Método estático para registrar una nueva película
        public static Pelicula RegistrarPelicula(string titulo, string genero, int duracionMinutos)
        {
            return new Pelicula(titulo, genero, duracionMinutos);
        }
    }
}
