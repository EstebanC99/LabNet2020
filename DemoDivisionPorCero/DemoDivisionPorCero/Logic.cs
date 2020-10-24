using DemoDivisionPorCero.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDivisionPorCero
{
    public class Logic
    {

        public static void ThrowException()
        {
            throw new Exception();
        }

        public static void ThrowPersonalizadaException(string mensaje)
        {
            throw new PersonalizadaException(mensaje);
        }

    }
}
