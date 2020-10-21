using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPOO
{
    public abstract class Mamifero
    {


        #region Atributos

        private int cantPatas;


        #endregion


        #region constructor

        public Mamifero(int cantPatas)
        {
            this.cantPatas = cantPatas;
        }
        #endregion


        #region Metodos Publicos

        public int CantPatas
        {
            get { return this.cantPatas; }
            set { this.cantPatas = value; }
        }

        public abstract string Hablar();
        public string Repirar()
        {
            return "Yo respiro";
        }
        public virtual string Caminar()
        {
            return "Yo camino";
        }
        #endregion
    }
}
