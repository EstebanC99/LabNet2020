using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic.Exceptions
{
    public class DbErrorException: Exception
    {

        public DbErrorException():base("Error desconocido") { }

        public DbErrorException(string mensaje) : base(mensaje) { }
    }
}
