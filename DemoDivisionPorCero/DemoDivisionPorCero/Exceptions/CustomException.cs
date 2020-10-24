using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDivisionPorCero.Exceptions
{
    public class CustomException: ArithmeticException
    {
        public CustomException() : base("A Einstein se le va a zafar un tornillo") { }

    }
}
