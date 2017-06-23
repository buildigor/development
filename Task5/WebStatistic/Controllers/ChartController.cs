using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using WebStatistic.Models;

namespace WebStatistic.Controllers
{
    public class ChartController : Controller
    {
        private IWorker _worker;

        public ChartController()
        {
            _worker = new Worker();
        }
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Chart()
        {
            return Json(Listdata(), JsonRequestBehavior.AllowGet);
        }
        public IEnumerable Listdata()
        {
            var managers = _worker.GetAllManagers();
            List<ChartModel> dataForCharts = (from manager in managers let content = _worker.GetAllOrdersForManager(manager.Id) select new ChartModel() {ManagerName = manager.Name, SalesCount = content.Count()}).ToList();
            var data = dataForCharts.AsEnumerable();
            return data;
        }
    }
}