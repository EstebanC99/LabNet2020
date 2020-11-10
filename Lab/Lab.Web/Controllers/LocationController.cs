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

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult Update(LocationModel entity)
        {
            return View(entity);
        }

        [HttpPost]
        public ActionResult UpdateLocation(LocationModel entity)
        {
            LocationLogic location = new LocationLogic();
            location.Update(new Entities.LOCATIONS() { ID = entity.Id, CITY = entity.City });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult InsertLocation(LocationModel newEntity)
        {
            LocationLogic location = new LocationLogic();
            location.Insert(new Entities.LOCATIONS() { CITY = newEntity.City });
            return RedirectToAction("Index");
        }

    }
}