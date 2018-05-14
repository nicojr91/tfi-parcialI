using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestParcial.Entities;
using TestParcial.UI.Process;

namespace TestParcial.UI.Web.Controllers
{
    public class SucursalController : Controller
    {
        private SucursalProcess process = new SucursalProcess();

        // GET: /Sucursal/
        public ActionResult Index()
        {
            var list = process.List();

            return View(list);
        }

        //
        // GET: /Sucursal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Sucursal/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sucursal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var s = new Sucursal();
                s.Zona = collection["zona"];
                s.Latitud = collection["latitud"];
                s.Longitud = collection["longitud"];

                process.Add(s);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sucursal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Sucursal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sucursal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Sucursal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
