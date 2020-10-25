using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOExceptions.Extensions
{
    public static class MensajeExtensions
    {
        public static string Message(this string mensaje, string mensajePersonalizado)
        {
            return $"{mensaje} {mensajePersonalizado}";
        }

    }
}
