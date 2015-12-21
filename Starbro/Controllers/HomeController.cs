using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Starbro.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var result = new FilePathResult("~/index.html", "text/html");
            return result;
           // return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}