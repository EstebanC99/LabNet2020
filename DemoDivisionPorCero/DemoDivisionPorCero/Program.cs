using DemoDivisionPorCero.Exceptions;
using DemoDivisionPorCero.Extensions;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDivisionPorCero
{
    class Program
    {
        static void Main(string[] args)
        {
            //Enunciado1();
            //Enunciado2();
            //Enunciado3();
            Enunciado4();
            Console.ReadKey();

        }

        static void Enunciado1()
        {
            Console.WriteLine("Ingrese el valor a dividir: ");
            int numero = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine($"El resultado es {numero.DividirPorCero()}.");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Fin de ejecucion");
            }
        }

        static void Enunciado2()
        {
            try
            {
                Console.WriteLine("Ingrese numero a dividir:");
                int dividendo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese numero divisor: ");
                int divisor = int.Parse(Console.ReadLine());
                Console.WriteLine(dividendo.DividirDosNumeros(divisor));
            }
            catch (ArithmeticException ex)
            {
                Exception customEx = new CustomException();
                Console.WriteLine($"{customEx.Message}, hubo un {ex.Message.ToLower()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Seguro ingreso una letra o no ingreso nada. {ex.Message}");
            }
        }

        static void Enunciado3()
        {
            try
            {
                Logic.ThrowException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} - {ex.GetType()}");
            }
            
        }

        static void Enunciado4()
        {
            string mensaje = Console.ReadLine();
            try
            {
                Logic.ThrowPersonalizadaException(mensaje);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.GetBaseException().Message}");
            }
        }
    }
}
