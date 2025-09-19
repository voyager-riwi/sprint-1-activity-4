using System;

namespace Sprint2Activity1
{
    public class CuentaBanco
    {
        // Propiedades
        public string NumeroCuenta { get; set; }
        public string NombreDueno { get; set; }
        public decimal Saldo { get; set; }

        // Constructor
        public CuentaBanco(string numeroCuenta, string nombreDueno, decimal saldoInicial = 0)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                throw new ArgumentException("El número de cuenta no puede estar vacío.", nameof(numeroCuenta));
            
            if (string.IsNullOrWhiteSpace(nombreDueno))
                throw new ArgumentException("El nombre del dueño no puede estar vacío.", nameof(nombreDueno));
            
            if (saldoInicial < 0)
                throw new ArgumentException("El saldo inicial no puede ser negativo.", nameof(saldoInicial));

            NumeroCuenta = numeroCuenta.Trim();
            NombreDueno = nombreDueno.Trim();
            Saldo = saldoInicial;
        }

        // Método para consultar el saldo
        public void ConsultarSaldo()
        {
            Console.WriteLine($"Consulta de Saldo:");
            Console.WriteLine($"Número de Cuenta: {NumeroCuenta}");
            Console.WriteLine($"Titular: {NombreDueno}");
            Console.WriteLine($"Saldo Actual: ${Saldo:F2}");
        }

        // Método para depositar dinero
        public void Depositar(decimal monto)
        {
            if (monto <= 0)
            {
                throw new ArgumentException("El monto del depósito debe ser mayor a cero.", nameof(monto));
            }

            if (monto > 1000000) // Límite de seguridad
            {
                throw new ArgumentException("El monto del depósito excede el límite máximo permitido ($1,000,000).", nameof(monto));
            }

            Saldo += monto;
            Console.WriteLine($"Depósito exitoso de ${monto:F2}");
            Console.WriteLine($"Nuevo saldo: ${Saldo:F2}");
        }

        // Método estático para abrir una nueva cuenta
        public static CuentaBanco AbrirCuenta(string numeroCuenta, string nombreDueno, decimal saldoInicial = 0)
        {
            return new CuentaBanco(numeroCuenta, nombreDueno, saldoInicial);
        }
    }
}
