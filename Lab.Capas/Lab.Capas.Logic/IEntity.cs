using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Capas.Logic
{
    interface IEntity<T, K>
    {
        List<T> GetAll();

        T GetOne(K clave);

        void Insert(T entity);

        void Delete(K clave);

        void Update(T entity);


    }
}
