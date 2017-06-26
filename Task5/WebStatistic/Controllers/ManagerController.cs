using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using BL.Models;
using BL.SpecificationForSearch;
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
            IList<SellingModels> sellingModelsList = sellings.Select(ToSellingModels).ToList();
            return View(sellingModelsList);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        // POST: Manager/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind(Include = "ClientName,ProductName,Date,Cost,ManagerName")] FormCollection collection)
        {
            if (!ModelState.IsValid) return View();
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
        [Authorize(Roles = "admin")]

        public ActionResult Edit(int id)
        {
            var content = _worker.GetOneSelling(id);
            return View(ToSellingModels(content));
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ClientName,ProductName,Date,Cost,Id")] FormCollection content)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                _worker.Update(new SellingModel()
                {
                    Id = Convert.ToInt32(content["Id"]),
                    ClientName = content["ClientName"],
                    ProductName = content["ProductName"],
                    Date = Convert.ToDateTime(content["Date"]),
                    Cost = Convert.ToDouble(content["Cost"])
                });
                return RedirectToAction("AllManagers");


            }
            catch (Exception e)
            {
                return View();
            }
        }
       // [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var sellingForDelete = _worker.GetOneSelling(id);
            ViewBag.DeleteSelling = sellingForDelete;
            return View(ToSellingModels(sellingForDelete));
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _worker.Delete(id);
                return RedirectToAction("AllManagers");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Search(FormCollection collection)
        {
            DateTime date;
            DateTime.TryParse(collection["Date"], out date);
            DateTime dateSearch = date;
            var content = _worker.Search(new SearchSpecification()
            {
                ProductName = collection["ProductName"],
                ClientName = collection["ClientName"],
                ManagerName = collection["ManagerName"],
                Date = dateSearch
            });
            IList<SellingModels> listsSellingModels = content.Select(ToSellingModels).ToList();
            return View("Details", listsSellingModels);
        }
        public SellingModels ToSellingModels(SellingModel viewSellingModel)
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