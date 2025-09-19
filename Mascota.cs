using System;

namespace Sprint2Activity1
{
    public class Mascota
    {
        // Propiedades
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }

        // Constructor
        public Mascota(string nombre, string especie, int edad)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la mascota no puede estar vacío.", nameof(nombre));
            
            if (string.IsNullOrWhiteSpace(especie))
                throw new ArgumentException("La especie de la mascota no puede estar vacía.", nameof(especie));
            
            if (edad < 0)
                throw new ArgumentException("La edad no puede ser negativa.", nameof(edad));
            
            if (edad > 50) // Límite razonable para la edad de una mascota
                throw new ArgumentException("La edad excede el límite máximo permitido (50 años).", nameof(edad));

            Nombre = nombre.Trim();
            Especie = especie.Trim();
            Edad = edad;
        }

        // Método para consultar los datos de la mascota
        public void ConsultarDatos()
        {
            Console.WriteLine($"Datos de la Mascota:");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Especie: {Especie}");
            Console.WriteLine($"Edad: {Edad} años");
            Console.WriteLine($"¿Es cachorro? {(EsCachorro() ? "Sí" : "No")}");
        }

        // Método para saber si una mascota es cachorro (menos de 2 años)
        public bool EsCachorro()
        {
            return Edad < 2;
        }

        // Método para obtener la etapa de vida de la mascota
        public string ObtenerEtapaVida()
        {
            if (Edad < 1)
            {
                return "Cachorro/Bebé";
            }
            else if (Edad < 2)
            {
                return "Cachorro";
            }
            else if (Edad < 7)
            {
                return "Adulto joven";
            }
            else if (Edad < 10)
            {
                return "Adulto";
            }
            else
            {
                return "Senior";
            }
        }

        // Método estático para registrar una nueva mascota
        public static Mascota RegistrarMascota(string nombre, string especie, int edad)
        {
            return new Mascota(nombre, especie, edad);
        }
    }
}
