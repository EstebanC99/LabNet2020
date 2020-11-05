using Lab.Capas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Capas.Logic
{
    public abstract class BaseLogic<T, K>
    {
        protected NorthwindContext context;

        public BaseLogic()
        {
            this.context = new NorthwindContext();
        }

        public abstract List<T> GetAll();

        public abstract T GetOne(K key);

        public abstract void Insert(T entity);

        public abstract void Update(T entity);

        public abstract void Delete(K key);
    }
}
