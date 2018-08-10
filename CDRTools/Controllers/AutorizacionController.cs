using CDRTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDRTools.Controllers
{
    public class AutorizacionController : Controller
    {
        // GET: Autorizacion
        public ActionResult Index()
        {
            using (CDRModel dbModel = new CDRModel())

                return View(dbModel.Autorizacions.ToList());
        }

        // GET: Autorizacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Autorizacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autorizacion/Create
        [HttpPost]
        public ActionResult Create(Autorizacion autorizacion)
        {
            try
            {
                using (CDRModel dbModel = new CDRModel())
                {
                    dbModel.Autorizacions.Add(autorizacion);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autorizacion/Edit/5
        public ActionResult Edit(int id)
        {
            using (CDRModel dbModel = new CDRModel())
            {
               
                return View(dbModel.Autorizacions.Where(x => x.Autorizacion_Codigo == id).FirstOrDefault());
            }
        }

        // POST: Autorizacion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Autorizacion autorizacion)
        {
            try
            {
                using (CDRModel dbModel = new CDRModel())
                {
                    dbModel.Entry(autorizacion).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autorizacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Autorizacion/Delete/5
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
