using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Capas.Logic.Extensions
{
    public static class ExceptionExtensions
    {
        public static string Message(this Exception ex, string mensajeDefault)
        {
            return ($"{ex.Message} - {mensajeDefault}");
        }
    }
}
