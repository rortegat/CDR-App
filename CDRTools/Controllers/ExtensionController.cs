using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CDRTools.Models;

namespace CDRTools.Controllers
{
    public class ExtensionController : Controller
    {
        // GET: Extension
        public ActionResult Index()
        {
            using(CDRModel dbModel = new CDRModel())

            return View(dbModel.Extension.ToList());
        }

        // GET: Extension/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Extension/Create
        [HttpPost]
        public ActionResult Crear(Extension extension)
        {
            try
            {
                using (CDRModel dbModel = new CDRModel()) {
                    dbModel.Extension.Add(extension);
                    dbModel.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Extension/Edit
        public ActionResult Editar(int id)
        {
            using (CDRModel dbModel = new CDRModel())
            {
                return View(dbModel.Extension.Where(x => x.Id_Extension == id).FirstOrDefault());
            }
        }

        // POST: Extension/Edit
        [HttpPost]
        public ActionResult Editar(int id, Extension extension)
        {
            try
            {
                using (CDRModel dbModel = new CDRModel())
                {
                    dbModel.Entry(extension).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Extension/Delete
        public ActionResult Eliminar(int id)
        {
            using (CDRModel dbModel = new CDRModel())
            {
                return View(dbModel.Extension.Where(x => x.Id_Extension == id).FirstOrDefault());
            }
        }

        // POST: Extension/Delete
        [HttpPost]
        public ActionResult Eliminar(int id, Extension extension)
        {
            try
            {
                using (CDRModel dbModel = new CDRModel())
                {
                    extension = dbModel.Extension.Where(x => x.Id_Extension == id).FirstOrDefault();
                    dbModel.Extension.Remove(extension);
                    dbModel.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
