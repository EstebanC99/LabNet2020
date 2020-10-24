using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDivisionPorCero.Extensions
{
    public static class IntegerExtensions
    {
        public static float DividirPorCero(this int dividendo)
        {
            return (float) dividendo / 0;
        }

        public static float DividirDosNumeros(this int dividendo, int divisor)
        {
            return (float) dividendo / divisor;
        }

    }
}
