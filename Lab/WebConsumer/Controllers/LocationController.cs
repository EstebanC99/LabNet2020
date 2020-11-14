using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebConsumer.Models;

namespace WebConsumer.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AddLoc()
        {
            LocationModel location = new LocationModel();
            location.City = "Ciudad";
            var resultado = Send<LocationModel>("https://localhost:44331/api/ApiLoc", location, "POST");
            return RedirectToAction("Index");
        }

        public string Send<T>(string url, T objectRequest, string method = "POST")
        {
            string result = "";
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);

                //peticion
                WebRequest request = WebRequest.Create(url);
                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 10000; //esto es opcional

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {

                result = e.Message;

            }
            return result;
        }
    }
}
