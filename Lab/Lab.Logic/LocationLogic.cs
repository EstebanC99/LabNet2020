
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
            return db.LOCATIONS.ToList();
        }

        public LOCATIONS GetOne(int key)
        {
            return db.LOCATIONS.FirstOrDefault(l => l.ID.Equals(key));
        }

        public void Insert(LOCATIONS entity)
        {
            entity.ID = this.GetNextId();
            db.LOCATIONS.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int key)
        {
            db.LOCATIONS.Remove(this.GetOne(key));
            db.SaveChanges();
        }

        public void Update(LOCATIONS entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        private int GetNextId()
        {
            return this.GetAll().Last().ID + 1;
        }

    }
}
