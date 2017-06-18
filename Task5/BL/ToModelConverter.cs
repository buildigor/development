using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using DAL;

namespace BL
{
  public static class ToModelConverter
    {
        public static SellingModel ToSellingModel(Selling selling)
        {
            return new SellingModel
            {
                ClientName = selling.Client.Name,
                Cost = selling.Cost,
                Date = selling.Date,
                Id = selling.Id,
                ManagerName = selling.Manager.Name,
                ProductName = selling.Product.Name
            };
        }
        public static ManagerModel ToManagerModel(Manager manager)
        {
            return new ManagerModel()
            {
                Id = manager.Id,
                Name = manager.Name
            };
        }
    }
}
