﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public abstract class Transporte: ITransporte
    {
        #region Atributos
        public int CantPasajeros { get; set; }
        #endregion

        

        #region Metodos

        public abstract string Avanzar();

        public abstract string Detenerse();
        #endregion





    }
}
