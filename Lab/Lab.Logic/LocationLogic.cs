using Lab.Logic.Exceptions;
using Lab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic
{
    public class LocationLogic: BaseLogic, IEntity<LOCATIONS, int>
    {

        public List<LOCATIONS> GetAll()
        {
            try
            {
                return db.LOCATIONS.ToList();
            }
            catch (Exception)
            {
                throw new EmptyDbException();
            }
        }

        public LOCATIONS GetOne(int key)
        {
            try
            {
                return db.LOCATIONS.FirstOrDefault(l => l.ID.Equals(key));
            }
            catch (Exception)
            {
                throw new EmptyDbException();
            }

        }

        public void Insert(LOCATIONS entity)
        {
            try
            {
                entity.ID = this.GetNextId();
                db.LOCATIONS.Add(entity);
                if (String.IsNullOrEmpty(entity.CITY))
                {
                    throw new DbErrorException("La ciudad es obligatoria");
                }
                db.SaveChanges();
            }
            catch (DbErrorException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new DbErrorException();
            }
        }

        public void Delete(int key)
        {
            try
            {
                db.LOCATIONS.Remove(this.GetOne(key));
                db.SaveChanges();
            } catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw new DbErrorException("No puede eliminarse este campo");
            }
            catch (Exception)
            {
                throw new DbErrorException();
            }

        }

        public void Update(LOCATIONS entity)
        {
            try
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                throw new DbErrorException("La ciudad es obligatoria");
            }
        }

        private int GetNextId()
        {
            return this.GetAll().Last().ID + 1;
        }

    }
}
