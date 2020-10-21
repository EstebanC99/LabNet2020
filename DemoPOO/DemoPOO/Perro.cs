using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPOO
{
    public class Perro : Mamifero
    {

        public Perro (int cantPatas): this.base;

        public override string Hablar()
        {
            return "Guau Guau";
        }

        public override string Caminar()
        {
            return base.Caminar() + " con las 4 patas";
        }
    }
}
