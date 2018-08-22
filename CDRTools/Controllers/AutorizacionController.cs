using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDRTools.Models;
using System.Data.Entity;

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





        // GET: Autorizacion/Create
        public ActionResult Crear()
        {
            CDRModel dbModel = new CDRModel();
            var viewModel = new ParentViewModel(dbModel.Extensions);

            return View(viewModel);

        }



        // POST: Autorizacion/Create
        //[HttpPost]
        public ActionResult CrearAutorizacion(string id_autorizacion, int codigo, string id_extension)
        {
            var nuevo = new Autorizacion() { Id_Autorizacion = id_autorizacion, Autorizacion_Codigo = codigo, Id_Extension = id_extension };

            try
            {
                using (CDRModel dbModel = new CDRModel())
                {
                    dbModel.Autorizacions.Add(nuevo);
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
        public ActionResult Editar(string id)
        {

            using (CDRModel dbModel = new CDRModel())
            {

                Autorizacion autorizacion = dbModel.Autorizacions.FirstOrDefault(x => x.Id_Autorizacion == id);
                if (autorizacion == null)
                {
                    return HttpNotFound();
                }
                return View(autorizacion);
            }

        }

        // POST: Autorizacion/Edit/5
        [HttpPost]
        public ActionResult Editar(String id, Autorizacion modificado)
        {
            using (CDRModel dbModel = new CDRModel())
            {
                try
                {
                   
                    Autorizacion actual = dbModel.Autorizacions.FirstOrDefault(x => x.Id_Autorizacion == id);
                    if (actual == null)
                        return HttpNotFound();
                    
                    actual.Autorizacion_Codigo = modificado.Autorizacion_Codigo;
                    actual.Id_Extension = modificado.Id_Extension;  

                    dbModel.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }

        // GET: Autorizacion/Delete/5

        public ActionResult Eliminar(string id)
        {
            using (CDRModel dbModel = new CDRModel())
            {
                return View(dbModel.Autorizacions.Where(x => x.Id_Autorizacion == id).FirstOrDefault());
            }
        }

        // POST: Extension/Delete
        [HttpPost]
        public ActionResult Eliminar(string id, Autorizacion autorizacion)
        {
            try
            {
                using (CDRModel dbModel = new CDRModel())
                {
                    autorizacion = dbModel.Autorizacions.Where(x => x.Id_Autorizacion == id).FirstOrDefault();
                    dbModel.Autorizacions.Remove(autorizacion);
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
