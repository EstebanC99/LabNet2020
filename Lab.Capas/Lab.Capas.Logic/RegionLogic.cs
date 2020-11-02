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
    public class RegionLogic
    {
        private readonly NorthwindContext context;
        #region Constructor
        public RegionLogic()
        {
            this.context = new NorthwindContext();
        }

        #endregion


        public List<Region> GetRegions()
        {
            return context.Region.ToList();
        }

        public Region GetRegion(int id)
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

        public void CargarRegion(string nombre)
        {
            try 
            {
                Region nuevaRegion = new Region();
                Region ultimaRegion = this.GetRegions().Last();
                nuevaRegion.RegionID = ultimaRegion.RegionID + 1;
                nuevaRegion.RegionDescription = nombre;
                context.Region.Add(nuevaRegion);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new CustomException();
            }
            
        }

        public void BorrarRegion(int id)
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

        public void ActualizarRegion(Region regionActualizada)
        {
            try
            {
                context.Entry(regionActualizada).CurrentValues.SetValues(regionActualizada.RegionID);
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
