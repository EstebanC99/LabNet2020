using Lab.Capas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Capas.Conexion
{
    public class NorthwindConnection
    {

        private readonly NorthwindContext context;

        public NorthwindConnection()
        {
            this.context = new NorthwindContext();
        }

    }
}
