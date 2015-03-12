using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity2Permission.Mvc.Areas.SuperAdmin.Controllers
{
    public class HomeController : Controller
    {
        // GET: SuperAdmin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}