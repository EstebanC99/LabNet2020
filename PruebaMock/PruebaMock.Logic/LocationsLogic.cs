using PruebaMock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMock.Logic
{
    public class LocationsLogic: EntitiesLogic
    {

        public List<LOCATIONS> GetAll()
        {
            return context.LOCATIONS.ToList();
        }

        public LOCATIONS GetOne(int key)
        {
            return context.LOCATIONS.FirstOrDefault(e => e.ID == key);
        }

        public void Insert(LOCATIONS entity)
        {

        }
    }
}
