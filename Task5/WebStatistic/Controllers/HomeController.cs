using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStatistic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Application about selling statistic.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact buildigor@gmail.com.";
            return View();
        }
    }
}