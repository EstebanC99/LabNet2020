using PruebaMock.Entities;
using PruebaMock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaMock.Logic.CustomExceptions;

namespace PruebaMock.Logic
{
    public class LocationsLogic: EntitiesLogic
    {
        public LocationsLogic() { }

        //Constructor usado en UnitTest con Mock
        public LocationsLogic(EmpresaContext newContext)
        {
            context = newContext;
        }

        public List<LOCATIONS> GetAll()
        {
            return context.LOCATIONS.ToList();
        }

        public LOCATIONS GetOne(int key)
        {
            try
            {
                return context.LOCATIONS.First(e => e.ID == key);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidIdException("No pudo encontrarse la localidad con el ID indicado");
            }

        }

        public void Insert(LOCATIONS entity)
        {
            if (entity.ID != 0)
            {
                try
                {
                    context.LOCATIONS.Add(entity);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            } else
            {
                throw new InvalidIdException();
            }
            
            
        }

        public void Delete(int key)
        {
            LOCATIONS entity = GetOne(key);
            context.LOCATIONS.Remove(entity);
            context.SaveChanges();
        }

        public void Update(LOCATIONS entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
