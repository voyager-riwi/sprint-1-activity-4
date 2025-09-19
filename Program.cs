using System;

namespace Sprint2Activity1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;
            
            while (keepRunning)
            {
                ShowMenu();
                int option = ReadOption();
                
                switch (option)
                {
                    case 1:
                        ExecuteExercise1();
                        break;
                    case 2:
                        ExecuteExercise2();
                        break;
                    case 3:
                        ExecuteExercise3();
                        break;
                    case 4:
                        ExecuteExercise4();
                        break;
                    case 5:
                        ExecuteExercise5();
                        break;
                    case 6:
                        ExecuteExercise6();
                        break;
                    case 7:
                        ExecuteExercise7();
                        break;
                    case 8:
                        ExecuteExercise8();
                        break;
                    case 9:
                        ExecuteExercise9();
                        break;
                    case 10:
                        ExecuteExercise10();
                        break;
                    case 0:
                        keepRunning = false;
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        break;
                }
                
                if (keepRunning)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("=== EJERCICIOS DE C# ===");
            Console.WriteLine("1. Estudiantes");
            Console.WriteLine("2. Banco");
            Console.WriteLine("3. Tienda");
            Console.WriteLine("4. Biblioteca");
            Console.WriteLine("5. Restaurante");
            Console.WriteLine("6. Parqueadero");
            Console.WriteLine("7. Cine");
            Console.WriteLine("8. Mascotas");
            Console.WriteLine("9. Hotel");
            Console.WriteLine("10. Clínica");
            Console.WriteLine("0. Salir");
            Console.Write("Selecciona una opción: ");
        }

        static int ReadOption()
        {
            while (true)
            {
                try
                {
                    int option = int.Parse(Console.ReadLine());
                    return option;
                }
                catch
                {
                    Console.Write("Por favor ingresa un número válido: ");
                }
            }
        }

        static string ReadText(string message)
        {
            Console.Write(message);
            string text = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(text))
            {
                Console.Write("Este campo es obligatorio. " + message);
                text = Console.ReadLine();
            }
            return text;
        }

        static int ReadInteger(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    int value = int.Parse(Console.ReadLine());
                    return value;
                }
                catch
                {
                    Console.WriteLine("Por favor ingresa un número entero válido.");
                }
            }
        }

        static decimal ReadDecimal(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    decimal value = decimal.Parse(Console.ReadLine());
                    return value;
                }
                catch
                {
                    Console.WriteLine("Por favor ingresa un número decimal válido.");
                }
            }
        }

        static void ExecuteExercise1()
        {
            Console.WriteLine("\n=== EJERCICIO 1: ESTUDIANTES ===");
            string name = ReadText("Ingresa el nombre del estudiante: ");
            int age = ReadInteger("Ingresa la edad: ");
            string grade = ReadText("Ingresa el grado escolar: ");
            
            var student = Estudiante.RegistrarEstudiante(name, age, grade);
            student.MostrarInformacion();
        }

        static void ExecuteExercise2()
        {
            Console.WriteLine("\n=== EJERCICIO 2: BANCO ===");
            string accountNumber = ReadText("Ingresa el número de cuenta: ");
            string ownerName = ReadText("Ingresa el nombre del titular: ");
            decimal initialBalance = ReadDecimal("Ingresa el saldo inicial: $");
            
            var account = CuentaBanco.AbrirCuenta(accountNumber, ownerName, initialBalance);
            account.ConsultarSaldo();
            
            Console.WriteLine("\n¿Deseas hacer un depósito? (s/n)");
            if (Console.ReadLine().ToLower() == "s")
            {
                decimal amount = ReadDecimal("Ingresa el monto a depositar: $");
                account.Depositar(amount);
            }
        }

        static void ExecuteExercise3()
        {
            Console.WriteLine("\n=== EJERCICIO 3: TIENDA ===");
            string name = ReadText("Ingresa el nombre del producto: ");
            decimal price = ReadDecimal("Ingresa el precio: $");
            int stock = ReadInteger("Ingresa la cantidad en stock: ");
            
            var product = Producto.RegistrarProducto(name, price, stock);
            product.ConsultarDetalles();
            
            Console.WriteLine("\n¿Deseas vender productos? (s/n)");
            if (Console.ReadLine().ToLower() == "s")
            {
                int quantity = ReadInteger("Ingresa la cantidad a vender: ");
                product.Vender(quantity);
            }
        }

        static void ExecuteExercise4()
        {
            Console.WriteLine("\n=== EJERCICIO 4: BIBLIOTECA ===");
            string title = ReadText("Ingresa el título del libro: ");
            string author = ReadText("Ingresa el autor: ");
            int pages = ReadInteger("Ingresa el número de páginas: ");
            
            var book = Libro.RegistrarLibro(title, author, pages);
            book.ConsultarInformacion();
        }

        static void ExecuteExercise5()
        {
            Console.WriteLine("\n=== EJERCICIO 5: RESTAURANTE ===");
            int tableNumber = ReadInteger("Ingresa el número de mesa: ");
            var order = Pedido.RegistrarPedido(tableNumber);
            
            bool addMoreDishes = true;
            while (addMoreDishes)
            {
                string dishName = ReadText("Ingresa el nombre del plato: ");
                decimal price = ReadDecimal("Ingresa el precio: $");
                order.AgregarPlato(dishName, price);
                
                Console.WriteLine("¿Deseas agregar otro plato? (s/n)");
                addMoreDishes = Console.ReadLine().ToLower() == "s";
            }
            
            order.MostrarInformacionPlatos();
        }

        static void ExecuteExercise6()
        {
            Console.WriteLine("\n=== EJERCICIO 6: PARQUEADERO ===");
            string plate = ReadText("Ingresa la placa del vehículo: ");
            string brand = ReadText("Ingresa la marca del vehículo: ");
            
            var vehicle = Vehiculo.RegistrarEntradaVehiculo(plate, brand);
            vehicle.RegistrarEntrada();
            
            Console.WriteLine("\n¿Deseas registrar la salida? (s/n)");
            if (Console.ReadLine().ToLower() == "s")
            {
                vehicle.RegistrarSalida();
                decimal hourlyRate = ReadDecimal("Ingresa el costo por hora: $");
                vehicle.CalcularCosto(hourlyRate);
            }
        }

        static void ExecuteExercise7()
        {
            Console.WriteLine("\n=== EJERCICIO 7: CINE ===");
            string title = ReadText("Ingresa el título de la película: ");
            string genre = ReadText("Ingresa el género: ");
            int duration = ReadInteger("Ingresa la duración en minutos: ");
            
            var movie = Pelicula.RegistrarPelicula(title, genre, duration);
            movie.ConsultarInformacion();
            Console.WriteLine($"Duración formateada: {movie.ObtenerDuracionFormateada()}");
        }

        static void ExecuteExercise8()
        {
            Console.WriteLine("\n=== EJERCICIO 8: MASCOTAS ===");
            string name = ReadText("Ingresa el nombre de la mascota: ");
            string species = ReadText("Ingresa la especie: ");
            int age = ReadInteger("Ingresa la edad en años: ");
            
            var pet = Mascota.RegistrarMascota(name, species, age);
            pet.ConsultarDatos();
            Console.WriteLine($"Etapa de vida: {pet.ObtenerEtapaVida()}");
        }

        static void ExecuteExercise9()
        {
            Console.WriteLine("\n=== EJERCICIO 9: HOTEL ===");
            int roomNumber = ReadInteger("Ingresa el número de habitación: ");
            string guestName = ReadText("Ingresa el nombre del huésped: ");
            int nights = ReadInteger("Ingresa la cantidad de noches: ");
            decimal pricePerNight = ReadDecimal("Ingresa el valor por noche: $");
            
            var reservation = Reserva.RegistrarReserva(roomNumber, guestName, nights, pricePerNight);
            reservation.ConsultarInformacion();
            reservation.MostrarInformacionDescuentos();
        }

        static void ExecuteExercise10()
        {
            Console.WriteLine("\n=== EJERCICIO 10: CLÍNICA ===");
            string patientName = ReadText("Ingresa el nombre del paciente: ");
            string specialty = ReadText("Ingresa la especialidad: ");
            
            Console.WriteLine("Ingresa la fecha de la cita (formato: dd/mm/yyyy):");
            DateTime appointmentDate;
            while (true)
            {
                try
                {
                    string dateString = Console.ReadLine();
                    appointmentDate = DateTime.ParseExact(dateString, "dd/MM/yyyy", null);
                    break;
                }
                catch
                {
                    Console.WriteLine("Formato de fecha inválido. Usa dd/mm/yyyy (ej: 15/12/2024):");
                }
            }
            
            var appointment = CitaMedica.RegistrarCita(patientName, specialty, appointmentDate);
            appointment.ConsultarDatos();
            appointment.MostrarInformacionDetallada();
        }
    }
}