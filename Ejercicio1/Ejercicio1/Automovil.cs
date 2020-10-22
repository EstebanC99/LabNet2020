using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class Automovil: Transporte
    {

        public Automovil(int cantPasajeros)
        {
            base.CantPasajeros = cantPasajeros;
        }

        public override string Avanzar()
        {
            return "Yo avanzo";
        }

        public override string Detenerse()
        {
            return "Yo freno";
        }
    }
}
