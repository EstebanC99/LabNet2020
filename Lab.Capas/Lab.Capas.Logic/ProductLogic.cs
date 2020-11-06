using Lab.Capas.Entities;
using Lab.Capas.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Capas.Logic
{
    public class ProductLogic: BaseLogic<Products, int>, IEntity<Products, int>
    {
        public override List<Products> GetAll()
        {
           return context.Products.ToList();
        }

        public override Products GetOne(int id)
        {
            try
            {
                return context.Products.First(r => r.ProductID.Equals(id));
            }
            catch (InvalidOperationException)
            {
                throw new CustomException("No existe la Products deseada");
            }
            catch (Exception)
            {
                throw new CustomException();
            }

        }

        public override void Insert(Products entity)
        {
            try
            {
                entity.ProductID = (from r in context.Products
                                   orderby r.ProductID descending
                                   select r.ProductID).FirstOrDefault() + 1;
                context.Products.Add(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new CustomException();
            }

        }

        public override void Delete(int id)
        {
            try
            {
                context.Products.Remove(context.Products.Find(id));
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new CustomException();
            }
        }

        public override void Update(Products entity)
        {
            try
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                throw new CustomException("No puede dejar campo vacio!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
