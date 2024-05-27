using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_VentaEntradas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variables para estadísticas
            int cantidadSol = 0, cantidadSombra = 0, cantidadPreferencial = 0;
            int acumuladoSol = 0, acumuladoSombra = 0, acumuladoPreferencial = 0;

            // Precios por localidad y cargos por servicio
            int precioLocalidad1 = 10500;
            int precioLocalidad2 = 20500;
            int precioLocalidad3 = 25500;
            int cargosXservicio = 1000;

            bool continuar = true;
            while (continuar)
            {
                // Leer datos de la venta
                Console.WriteLine("Nombre: ");
                string nombre = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Número de Factura: ");
                int numeroFactura = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Número de Cédula: ");
                int cedula = Convert.ToInt32(Console.ReadLine());

                int localidad;
                do
                {
                    Console.Write("Localidad (1-Sol Norte/Sur, 2-Sombra Este/Oeste, 3-Preferencial): ");
                } while (!int.TryParse(Console.ReadLine(), out localidad) || localidad < 1 || localidad > 3);

                int cantidadEntradas;
                do
                {
                    Console.Write("Cantidad de Entradas (máximo 4): ");
                } while (!int.TryParse(Console.ReadLine(), out cantidadEntradas) || cantidadEntradas < 1 || cantidadEntradas > 4);

                // Procesar los datos
                string nombreLocalidad = "";
                int precioEntrada = 0;

                switch (localidad)
                {
                    case 1:
                        nombreLocalidad = "Sol Norte/Sur";
                        precioEntrada = precioLocalidad1;
                        break;
                    case 2:
                        nombreLocalidad = "Sombra Este/Oeste";
                        precioEntrada = precioLocalidad2;
                        break;
                    case 3:
                        nombreLocalidad = "Preferencial";
                        precioEntrada = precioLocalidad3;
                        break;
                }

                int subtotal = cantidadEntradas * precioEntrada;
                int totalCargosXservicio = cantidadEntradas * cargosXservicio;
                int totalPagar = subtotal + totalCargosXservicio;

                // Mostrar información de la venta
                Console.WriteLine("\n=== Detalle de la Venta ===");
                Console.WriteLine($"Número de Factura: {numeroFactura}");
                Console.WriteLine($"Cédula: {cedula}");
                Console.WriteLine($"Nombre Comprador: {nombre}");
                Console.WriteLine($"Localidad: {nombreLocalidad}");
                Console.WriteLine($"Cantidad de Entradas: {cantidadEntradas}");
                Console.WriteLine($"Subtotal: {subtotal} colones");
                Console.WriteLine($"Cargos por Servicios: {totalCargosXservicio} colones");
                Console.WriteLine($"Total a Pagar: {totalPagar} colones");
                Console.WriteLine("==========================\n");

                // Actualizar estadísticas
                switch (localidad)
                {
                    case 1:
                        cantidadSol += cantidadEntradas;
                        acumuladoSol += subtotal;
                        break;
                    case 2:
                        cantidadSombra += cantidadEntradas;
                        acumuladoSombra += subtotal;
                        break;
                    case 3:
                        cantidadPreferencial += cantidadEntradas;
                        acumuladoPreferencial += subtotal;
                        break;
                }

                // Preguntar si se desea continuar
                Console.Write("¿Desea ingresar otra venta? (s/n): ");
                continuar = Console.ReadLine().ToLower() == "s";
            }

            // Mostrar estadísticas
            Console.WriteLine("\n=== Estadísticas ===");
            Console.WriteLine($"Cantidad Entradas Localidad Sol Norte/Sur: {cantidadSol}");
            Console.WriteLine($"Acumulado Dinero Localidad Sol Norte/Sur: {acumuladoSol} colones");
            Console.WriteLine($"Cantidad Entradas Localidad Sombra Este/Oeste: {cantidadSombra}");
            Console.WriteLine($"Acumulado Dinero Localidad Sombra Este/Oeste: {acumuladoSombra} colones");
            Console.WriteLine($"Cantidad Entradas Localidad Preferencial: {cantidadPreferencial}");
            Console.WriteLine($"Acumulado Dinero Localidad Preferencial: {acumuladoPreferencial} colones");
            Console.WriteLine("====================\n");
        }
    }
}
