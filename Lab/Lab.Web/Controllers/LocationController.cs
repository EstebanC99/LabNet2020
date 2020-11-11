using Lab.Logic;
using Lab.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Web.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            LocationLogic location = new LocationLogic();
            List<LocationModel> locations = (from l in location.GetAll()
                                            select new LocationModel { Id = l.ID, City = l.CITY }).ToList();

            return View(locations);
        }

        public ActionResult Delete(int key)
        {
            LocationLogic location = new LocationLogic();
            location.Delete(key);
            return RedirectToAction("Index");
        }

        //LLAMA A LA VISTA DE UPDATE O INSERT, SETEANDO EL TITULO CORRESPONDIENTE
        public ActionResult InsertUpdate(LocationModel entity, string accion)
        {
            ViewBag.Title = accion;
            return View(entity);
        }

        //EJECUTA METODO SI QUIERE ACTUALIZAR O AGREGAR
        [HttpPost]
        public ActionResult InsertOrUpdate(LocationModel entity)
        {
            LocationLogic location = new LocationLogic();
            if (entity.Id != 0)
            {
                location.Update(new Entities.LOCATIONS() { ID = entity.Id, CITY = entity.City });
            }   else
            {
                location.Insert(new Entities.LOCATIONS() { CITY = entity.City });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

    }
}