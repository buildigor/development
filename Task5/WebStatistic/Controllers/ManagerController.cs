using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using BL.Models;
using WebStatistic.Models.WorkModels;

namespace WebStatistic.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IWorker _worker;

        public ManagerController()
        {
            _worker = new Worker();
        }
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllManagers()
        {
            var managers = _worker.GetAllManagers();
            IList<ManagerModels> listOfManagers = managers.Select(manager => new ManagerModels()
            {
                Id = manager.Id,
                Name = manager.Name
            }).ToList();
            return View(listOfManagers);
        }

        public ActionResult Details(int id)
        {
            var sellings = _worker.GetAllOrdersForManager(id);
            IList<SellingModels> sellingModelsList = sellings.Select(ExtensionsMethod.ToSellingModels).ToList();
            return View(sellingModelsList);
        }
        public ActionResult Create()
        {
            return View();
        }
        // POST: Manager/Create
        [HttpPost]
       // [Authorize]
        public ActionResult Create([Bind(Include = "ClientName,ProductName,Date,Cost,ManagerName")] FormCollection collection)
        {
            try
            {
                _worker.AddNew(new SellingModel()
                {
                    ManagerName = collection["ManagerName"],
                    ClientName = collection["ClientName"],
                    ProductName = collection["ProductName"],
                    Date = Convert.ToDateTime(collection["Date"]),
                    Cost = Convert.ToDouble(collection["Cost"])

                });

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public static class ExtensionsMethod
        {
            public static SellingModels ToSellingModels(SellingModel viewSellingModel)
            {
                return new SellingModels()
                {
                    Id = viewSellingModel.Id,
                    ManagerName = viewSellingModel.ManagerName,
                    ClientName = viewSellingModel.ClientName,
                    Date = viewSellingModel.Date.Date,
                    ProductName = viewSellingModel.ProductName,
                    Cost = viewSellingModel.Cost
                };
            }
        }
    }
}