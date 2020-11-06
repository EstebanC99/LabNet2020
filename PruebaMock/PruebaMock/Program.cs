using PruebaMock.Entities;
using PruebaMock.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMock
{
    class Program
    {
        static void Main(string[] args)
        {
            var locationsLogic = new LocationsLogic();
            foreach (LOCATIONS l in locationsLogic.GetAll())
            {
                Console.WriteLine(l.ID);
            }
            Console.ReadKey();
        }
    }
}
