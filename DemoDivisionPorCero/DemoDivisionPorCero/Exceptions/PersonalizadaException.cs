using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDivisionPorCero.Exceptions
{
    public class PersonalizadaException: Exception
    {

        public PersonalizadaException(string mensaje): base (mensaje){ }

    }
}
