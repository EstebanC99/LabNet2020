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
            char opcion;
            do
            {
                CargaMenu();
                Console.Write("Ingrese una opcion: ");
                opcion = Console.ReadLine()[0];
                switch (opcion)
                {
                    case '1':
                        IngresarUnNumero();
                        break;
                    case '2':
                        IngresarDosNumeros();
                        break;
                    case '3':
                        Ejercicio3();
                        break;
                    case '4':
                        Ejercicio4();
                        break;
                    case '0':

                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (opcion != '0');
        }

        //Resuelve punto 2 de los ejercicios
        public static void IngresarDosNumeros()
        {
            Console.WriteLine("Ingrese el primer numero");
            try
            {
                int num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el primer numero");
                int num2 = int.Parse(Console.ReadLine());
                Console.WriteLine(num1.DividirPor(num2));
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message("Seguro ingreso una letra o nada!"));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message("Solo Chuck Norris divide por cero si Statham lo autoriza"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //Resuelve punto uno de los ejercicios
        public static void IngresarUnNumero()
        {
            Console.WriteLine("Ingrese un numero: ");
            try
            {
                int numero = int.Parse(Console.ReadLine());
                Console.WriteLine(numero.DividirPorCero());
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Fin de ejecucion");
            }
        }

        //Arroja una excepcion del tipo Exception
        public static void Ejercicio3()
        {
            try
            {
                Logic.DispararExcepcion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} del tipo {ex.GetType()}");
            }
        }
        
        //Arroja una excepcion personalizada con mensaje personalizado
        public static void Ejercicio4()
        {
            try
            {
                Console.WriteLine("Ingrese mensaje personalizado: ");
                Logic.DispararExcepcionPersonalizada(Console.ReadLine());
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"{ex.Message("Einstein esta muy decepcionado. ")}");
            }
        }

        public static void CargaMenu()
        {
            Console.WriteLine($"Ingrese: \n\t 1) Ejercicio 1 \n\t 2) Ejercicio 2 \n\t 3) Ejercicio 3 \n\t 4) Ejercicio 4 \n\t 0) Salir");
        }
    }
}
