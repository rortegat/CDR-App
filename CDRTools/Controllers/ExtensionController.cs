using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDRTools.DBServices;
using System.Web.Mvc;
using CDRTools.Models;

namespace CDRTools.Controllers
{
    public class ExtensionController : Controller
    {
        public ActionResult Extensiones()
        {
            ViewData["Message"] = "Edita tus extensiones";

            return View("Index");
        }

        public ActionResult Crear() {
            return View("_CrearExtension");
        }

    }
}
/*
        // GET: Extension/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Extension/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Extension/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Extension/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Extension/Edit/5
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

        // GET: Extension/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Extension/Delete/5
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
}*/
