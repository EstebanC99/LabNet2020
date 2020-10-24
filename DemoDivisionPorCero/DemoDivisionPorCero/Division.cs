using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDivisionPorCero
{
    class Division
    {

        private int dividendo;
        #region constructor
        public Division(int dividendo)
        {
            this.dividendo = dividendo;
        }
        #endregion

        #region Metodos

        public int DividirPorCero()
        {
            return this.dividendo / 0;
        }
        #endregion
    }
}
