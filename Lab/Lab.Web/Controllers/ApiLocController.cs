using Lab.Logic;
using Lab.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab.Web.Controllers
{
    public class ApiLocController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AddLoc(LocationModel entity)
        {
            LocationLogic newLocation = new LocationLogic();

            newLocation.Insert(new Entities.LOCATIONS()
            {
                CITY = entity.City
            });
            return Ok("Exito");
        }
    }
}
