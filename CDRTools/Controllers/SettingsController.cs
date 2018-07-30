using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDRTools.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfigMenu()
        {
            return View("_ConfigMenu");
        }
        public ActionResult LeerArchivo()
        {
            return View("_LeerArchivo");
        }
    }
}