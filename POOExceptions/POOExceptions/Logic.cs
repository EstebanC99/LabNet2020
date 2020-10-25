using POOExceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOExceptions
{
    public class Logic
    {

        public static void DispararExcepcion()
        {
            throw new System.Exception();
        }

        public static void DispararExcepcionPersonalizada(string mensaje)
        {
            throw new CustomException(mensaje);
        }
    }
}
