using Lab.Capas.Data;
using Lab.Capas.Entities;
using Lab.Capas.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Capas.Logic
{
 
    public class TerritoriesLogic: BaseLogic, IEntity<Territories, string>
    {
        public List<Territories> GetAll()
        {
            return context.Territories.ToList();
        }

        public Territories GetTerritoryDescrip(string descrip)
        {
            try 
            { 
                return context.Territories.First(t => t.TerritoryDescription.ToLower().Equals(descrip.ToLower()));
            }
            catch (InvalidOperationException)
            {
                throw new CustomException("No existe el territorio deseado");
            }
            catch (Exception)
            {
                throw new CustomException();
            }
        }

        public Territories GetOne(string key)
        {
            try
            {
                return context.Territories.First(t => t.TerritoryID.Equals(key));
            }
            catch (InvalidOperationException)
            {
                throw new CustomException("No existe el territorio deseado");
            }
            catch (Exception)
            {
                throw new CustomException();
            }
        }

        public void Insert(Territories entity)
        {
            try { 
                context.Territories.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Delete(string key)
        {
            try
            {
                context.Territories.Remove(context.Territories.Find(key));
                context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                throw new CustomException("No existe el territorio deseado");
            }
            catch (Exception)
            {
                throw new CustomException();
            }
        }

        public void Update(Territories entity)
        {
            try
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                throw new CustomException("No puede dejar campo vacio!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
