using System;
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
            Console.WriteLine("Ingrese el valor a dividir: ");
            Division division = new Division(int.Parse(Console.ReadLine()));
            try
            {
                int resultado = division.DividirPorCero();
                Console.WriteLine($"El resultado es {resultado}.");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

        }
    }
}
