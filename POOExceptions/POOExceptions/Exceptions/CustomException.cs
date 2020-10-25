using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOExceptions.Exceptions
{
    public class CustomException: Exception
    {
        public CustomException(string mensaje) : base(mensaje) { }
    }
}
