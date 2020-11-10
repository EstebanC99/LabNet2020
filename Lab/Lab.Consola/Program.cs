using Lab.Entities;
using Lab.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Consola
{
    class Program
    {

        static void Main(string[] args)
        {
            List<LOCATIONS> locations = new LocationLogic().GetAll();
            foreach(var l in locations)
            {
                Console.WriteLine($"{l.ID} - {l.CITY}");
            }
            Console.ReadKey();
        }
    }
}
