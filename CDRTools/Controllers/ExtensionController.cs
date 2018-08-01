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
        public ActionResult Index() {
            ViewData["Message"] = "Extensiones";

            return View();
        }

        public ActionResult Crear() {
            return View("_CrearExtension");
        }

        public ActionResult Mostrar() {

            ExtensionesDBService ExtService = new ExtensionesDBService();
            var data = ExtService.Extensiones_Recupera();
            //var extensionId = data.ToList();



            //ViewBag["message"] = data;

            return View("_MostrarExtensiones");
        }

    }
}
