using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Capas.Logic.Exceptions
{
    public class CustomException: Exception
    {

        public CustomException(string mensaje) : base(mensaje) { }

        public CustomException() : base("Oops! Ocurrio un error inesperado") { }

    }
}
