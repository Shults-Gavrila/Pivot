using CsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ForexPivot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            //table.Find("tbody").Eq(0).Find("tr").Eq(0).Find("td").Eq(1).Text();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}