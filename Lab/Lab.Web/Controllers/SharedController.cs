using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Web.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult LoadUser(string user)
        {
            Session["User"] = user;
            return RedirectToAction("Index","Home");
        }
    }
}