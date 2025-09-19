using System;

namespace Sprint2Activity1
{
    public class Estudiante
    {
        // Propiedades
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string GradoEscolar { get; set; }

        // Constructor
        public Estudiante(string nombre, int edad, string gradoEscolar)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del estudiante no puede estar vacío.", nameof(nombre));
            
            if (edad < 0 || edad > 120)
                throw new ArgumentException("La edad debe estar entre 0 y 120 años.", nameof(edad));
            
            if (string.IsNullOrWhiteSpace(gradoEscolar))
                throw new ArgumentException("El grado escolar no puede estar vacío.", nameof(gradoEscolar));

            Nombre = nombre.Trim();
            Edad = edad;
            GradoEscolar = gradoEscolar.Trim();
        }

        // Método para mostrar información del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine($"Información del Estudiante:");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Edad: {Edad} años");
            Console.WriteLine($"Grado Escolar: {GradoEscolar}");
        }

        // Método estático para registrar un nuevo estudiante
        public static Estudiante RegistrarEstudiante(string nombre, int edad, string gradoEscolar)
        {
            return new Estudiante(nombre, edad, gradoEscolar);
        }
    }
}
