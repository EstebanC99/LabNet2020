using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            var auto = new Automovil();
            Console.Write("Ingrese cantidad de pasajeros: ");
            auto.CantPasajeros= Int32.Parse(Console.ReadLine());
            Console.WriteLine("El auto tiene " + auto.CantPasajeros + "pasajeros.");
            Console.ReadKey();
        }
    }
}
