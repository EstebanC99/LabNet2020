using Lab.Capas.Data;
using Lab.Capas.Entities;
using Lab.Capas.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Capas.Logic
{
 
    public class TerritoriesLogic
    {
        private readonly NorthwindContext context;

        #region Constructor
        public TerritoriesLogic()
        {
            this.context = new NorthwindContext();
        }
        #endregion

        public List<Territories> GetTerritories()
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

        public Territories GetTerritory(string key)
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

        public void CargarTerritory(string key, string descrip, int regionId)
        {
            try { 
            Territories newTerritory = new Territories();
            newTerritory.TerritoryID = key;
            newTerritory.TerritoryDescription = descrip;
            newTerritory.RegionID = regionId;
            context.Territories.Add(newTerritory);
            context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void BorrarTerritory(string key)
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
    }
}
