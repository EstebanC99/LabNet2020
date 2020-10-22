using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class Avion : Transporte
    {

        public Avion(int cantPasajeros)
        {
            base.CantPasajeros = cantPasajeros;
        }

        public override string Avanzar()
        {
            return "Yo vuelo";
        }

        public override string Detenerse()
        {
            return "Yo aterrizo";
        }
    }
}
