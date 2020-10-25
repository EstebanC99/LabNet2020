using POOExceptions.Exceptions;
using POOExceptions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un numero: ");
            int numero = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(numero.DividirPorCero());
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            finally
            {
                Console.WriteLine("Fin de ejecucion");
            }


            try
            {
                Logic.DispararExcepcion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} del tipo {ex.GetType()}");
            }

            try
            {
                Console.WriteLine("Ingrese mensaje personalizado: ");
                Logic.DispararExcepcionPersonalizada(Console.ReadLine()); ;
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            Console.ReadKey();
        }

        public void IngresarDosNumeros()
        {
            Console.WriteLine("Ingrese el primer numero");
            try
            {
                int num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el primer numero");
                int num2 = int.Parse(Console.ReadLine());
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
