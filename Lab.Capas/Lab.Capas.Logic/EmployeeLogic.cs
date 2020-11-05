using Lab.Capas.Data;
using Lab.Capas.Entities;
using Lab.Capas.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Capas.Logic
{
    public class EmployeeLogic: BaseLogic<Employees, string>, IEntity<Employees, string>
    {
        public override List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public override Employees GetOne(string nombre)
        {
            try
            {
                return context.Employees.First(e => e.FirstName.ToLower().Equals(nombre.ToLower()));
            }
            catch (InvalidOperationException)
            {
                throw new CustomException("No hay empleados con ese nombre");
            }
            catch (Exception)
            {
                throw new CustomException();
            }
        }

        public override void Insert(Employees entity)
        {

        }

        public override void Delete(string key)
        {

        }

        public override void Update(Employees entity)
        {

        }

    }
}
