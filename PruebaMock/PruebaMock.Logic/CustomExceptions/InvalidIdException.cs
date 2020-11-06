using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMock.Logic.CustomExceptions
{
    public class InvalidIdException: Exception
    {
        public InvalidIdException() : base("El ID ingresado es invalido") { }
        public InvalidIdException(string mensaje): base(mensaje) { }

    }
}
