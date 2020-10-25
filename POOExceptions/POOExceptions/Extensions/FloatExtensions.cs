using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOExceptions.Extensions
{
    public static class FloatExtensions
    {

        public static float DividirPorCero(this int numero)
        {
            return (numero / 0);
        }

        public static decimal DividirPor(this int dividendo, int divisor)
        {
            try
            {
                return (decimal)dividendo / divisor;
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  
    }
}
