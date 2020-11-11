using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic.Exceptions
{
    public class EmptyDbException: Exception
    {

        public EmptyDbException() : base("La tabla elegida se encuentra vacia") { }

        public EmptyDbException(string mensaje) : base(mensaje) { }

    }
}
