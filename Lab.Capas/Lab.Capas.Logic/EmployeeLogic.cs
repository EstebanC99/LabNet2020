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
    public class EmployeeLogic: BaseLogic, IEntity<Employees, string>
    {
        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employees GetOne(string nombre)
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

    }
}
