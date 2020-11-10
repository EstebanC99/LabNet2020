using Lab.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic
{
    public abstract class BaseLogic
    {
        protected dbPractica db;

        public BaseLogic()
        {
             this.db = new dbPractica();
        }
    }
}
