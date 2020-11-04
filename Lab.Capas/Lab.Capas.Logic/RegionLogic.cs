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
    public class RegionLogic: BaseLogic, IEntity<Region, int>
    {

        public List<Region> GetAll()
        {
            return context.Region.ToList();
        }

        public Region GetOne(int id)
        {
            try
            {
                return context.Region.First(r => r.RegionID.Equals(id));
            }
            catch (InvalidOperationException)
            {
                throw new CustomException("No existe la region deseada");
            }
            catch (Exception)
            {
                throw new CustomException();
            }

        }

        public void Insert(Region entity)
        {
            try 
            {
                entity.RegionID = (from r in context.Region
                                        orderby r.RegionID descending
                                        select r.RegionID).FirstOrDefault() +1;
                context.Region.Add(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new CustomException();
            }
            
        }

        public void Delete(int id)
        {
            try
            {
                context.Region.Remove(context.Region.Find(id));
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new CustomException();
            }
        }

        public void Update(Region entity)
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
