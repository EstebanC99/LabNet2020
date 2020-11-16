using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebConsumer.Models;

namespace WebConsumer.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index(Main weather)
        {
            ViewBag.Error = TempData["Error"];
            ViewBag.Weather = weather;
            ViewBag.City = TempData["City"];
            List<LocationModel> locations = GetLocations();
            return View(locations);
        }

        public ActionResult TheWeather(string city)
        {
            try
            {
                var weather = AskWeather(city);
                TempData["City"] = city;
                return RedirectToAction("Index", weather);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", new Main ());
            }

        }


        //RETORNA UNICAMENTE INFO BASE DEL CLIMA (MAIN)
        public Main AskWeather(string CITY) 
        {
            var url = ("http://" + $"api.openweathermap.org/data/2.5/weather?q={CITY}&units=metric&appid=1325eed5954aa3432564f94dcef08161");
            var uri= new Uri(url);
            var json = GetInfo<WeatherModel>(uri);
            WeatherModel weather = JsonConvert.DeserializeObject<WeatherModel>(json);
            return weather.Main;
        }

        // RETORNA LISTA DE LAS UBICACIONES ACTUALES
        public List<LocationModel> GetLocations()
        {
            var uri = new Uri("https://localhost:44331/api/ApiLoc");
            
            string json = GetInfo<LocationModel>(uri);

            //Deserializa el objeto Json a la clase C#
            var oLocations = JsonConvert.DeserializeObject<List<LocationModel>>(json);
            return oLocations;
        }


        // REGRESA STRING DE LA CLASE JSON SERIALIZADA
        [HttpGet]
        public string GetInfo<R>(Uri uri)
        {
            string json;
            //peticion
            WebRequest request = WebRequest.Create(uri);
            //headers
            request.Method = "GET";
            request.PreAuthenticate = false;
            request.ContentType = "application/json;charset=utf-8'";
            request.Timeout = 10000; //esto es opcional

            //Envia la peticion esperando respuesta
            var httpResponse = (HttpWebResponse)request.GetResponse();

            //Lee la respuesta 
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                json = streamReader.ReadToEnd();
            }

            return json;
        }





        // RECIBE LA CIUDAD A INGRESAR Y LLAMA A LA FUNCION API
        [HttpPost]
        public ActionResult AddLoc(string city)
        {
            LocationModel location = new LocationModel();
            location.City = city;
            var resultado = Send<LocationModel>("https://localhost:44331/api/ApiLoc", location, "POST");
            return RedirectToAction("Index");
        }


        // EJECUCION DEL API REQUEST
        public string Send<T>(string url, T objectRequest, string method = "POST")
        {
            string result = "";
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = JsonConvert.SerializeObject(objectRequest);

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
