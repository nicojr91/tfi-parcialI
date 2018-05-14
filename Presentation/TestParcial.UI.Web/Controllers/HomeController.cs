using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TestParcial.Entities;
using TestParcial.UI.Process;
using TFIParcial.UI.Process;

namespace TFIParcial.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private DistanceProcess distanceProcess = new DistanceProcess();
        private PriceProcess priceProcess = new PriceProcess();
        private SucursalProcess sucursalProcess = new SucursalProcess();

        public ActionResult Index()
        {
            ViewBag.sucursales = sucursalProcess.List();

            return View();
        }

        public JsonResult GetPrice()
        {
            string origin = Request["origin"];
            string place = Request["place"];

            var km = Convert.ToInt32(Math.Floor(float.Parse(distanceProcess.GetDistance(origin, place))));

            var price = priceProcess.FindByKm(km);

            var json = new { success = true, totalKm = km, kmPrice = price.Kilometers, price = price.Value };

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSucursal()
        {
            int id = Int32.Parse(Request["id"]);

            Sucursal suc = sucursalProcess.FindById(id);

            var json = new { success = true, suc = suc };

            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}