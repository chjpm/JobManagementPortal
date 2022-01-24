using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENU.EJM.Web.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles ="Admin, Employee")]
        public ActionResult About()
        {
            ViewBag.Message = "Engineering Job Management Portal Details";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}