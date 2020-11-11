using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic.Exceptions
{
    public class EntityNotFoundException: Exception
    {

        public EntityNotFoundException():base("No se encontraron coincidencias") { }


    }
}
