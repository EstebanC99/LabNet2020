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
            var newLocation = new LOCATIONS() { ID = 1 };
            locationsLogic.Insert(newLocation);
            Console.ReadKey();
        }
    }
}
