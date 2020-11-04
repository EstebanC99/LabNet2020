using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Capas.Logic
{
    interface IEntity<T, in P>
    {
        List<T> GetAll();

        T GetOne(P clave);
    }
}
