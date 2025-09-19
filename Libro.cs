using System;

namespace Sprint2Activity1
{
    public class Libro
    {
        // Propiedades
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int NumeroPaginas { get; set; }

        // Constructor
        public Libro(string titulo, string autor, int numeroPaginas)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("El título del libro no puede estar vacío.", nameof(titulo));
            
            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("El autor del libro no puede estar vacío.", nameof(autor));
            
            if (numeroPaginas <= 0)
                throw new ArgumentException("El número de páginas debe ser mayor a cero.", nameof(numeroPaginas));
            
            if (numeroPaginas > 10000) // Límite razonable para un libro
                throw new ArgumentException("El número de páginas excede el límite máximo permitido (10,000).", nameof(numeroPaginas));

            Titulo = titulo.Trim();
            Autor = autor.Trim();
            NumeroPaginas = numeroPaginas;
        }

        // Método para consultar la información del libro
        public void ConsultarInformacion()
        {
            Console.WriteLine($"Información del Libro:");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Número de páginas: {NumeroPaginas}");
            Console.WriteLine($"¿Es un libro largo? {(EsLibroLargo() ? "Sí" : "No")}");
        }

        // Método para saber si un libro tiene más de 300 páginas
        public bool EsLibroLargo()
        {
            return NumeroPaginas > 300;
        }

        // Método estático para registrar un nuevo libro
        public static Libro RegistrarLibro(string titulo, string autor, int numeroPaginas)
        {
            return new Libro(titulo, autor, numeroPaginas);
        }
    }
}
