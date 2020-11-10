using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic
{
    interface IEntity<T, in K>
    {
        List<T> GetAll();

        T GetOne(K clave);


    }
}
