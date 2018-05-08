using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestParcial.Entities;
using TestParcial.UI.Process;

namespace TestParcial.UI.Web.Controllers
{
    public class PriceController : Controller
    {
        private PriceProcess process = new PriceProcess();

        //
        // GET: /Price/
        public ActionResult Index()
        {
            var list = process.List();

            return View(list);
        }

        //
        // GET: /Price/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Price/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Price/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var p = new Price();
                p.Kilometers = Int32.Parse(collection["kilometers"]);
                p.Value = float.Parse(collection["value"]);

                process.Add(p);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Price/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Price/Edit/5
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
        // GET: /Price/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Price/Delete/5
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
