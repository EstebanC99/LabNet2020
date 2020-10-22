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
            List<Transporte> transportes = new List<Transporte>();
            Random random = new Random();

            for (int x = 1; x <=5; x++)
            {
                var auto = new Automovil(random.Next(1, 6));
                System.Threading.Thread.Sleep(100);
                var avion = new Avion(random.Next(1, 101));
                System.Threading.Thread.Sleep(100);
                transportes.Add(auto);
                transportes.Add(avion);
            }

            int i = 0;
            var aviones = (from t in transportes
                           where t is Avion
                           select t);
            var autos = (from t in transportes
                         where t is Automovil
                         select t);

            foreach (Automovil a in autos)
            {
                Console.WriteLine("Automovil " + ++i + ": " + a.CantPasajeros + " pasajeros. {0}, {1}", a.Avanzar(), a.Detenerse());
            }
            Console.WriteLine();
            i = 0;
            foreach (Avion a in aviones)
            {
                Console.WriteLine("Avion " + ++i + ": " + a.CantPasajeros + " pasajeros. {0}, {1}", a.Avanzar(), a.Detenerse());
            }
            Console.ReadKey();
        }
    }
}
