using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOExceptions.Extensions
{
    public static class MensajeExtensions
    {
        //Realiza una sobrecarga al metodo Message para agregar al comienzo un mensaje personalizado
        public static string Message(this Exception ex, string mensajePersonalizado)
        {
            return $"{mensajePersonalizado} - {ex.Message}";
        }

    }
}
