using Lab.Capas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Capas.Logic
{
    public abstract class BaseLogic
    {
        protected NorthwindContext context;

        public BaseLogic()
        {
            this.context = new NorthwindContext();
        }
    }
}
