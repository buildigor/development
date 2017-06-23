using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.SpecificationForSearch;

namespace BL
{
    public interface IWorker
    {
        IList<ManagerModel> GetAllManagers();
        IList<SellingModel> GetAllSellings();
        IList<SellingModel> GetAllOrdersForManager(int id);
        SellingModel GetOneSelling(int id);
        void AddNew(SellingModel sellingModel);
        void Update(SellingModel sellingModel);
        void Delete(int id);
        IEnumerable<SellingModel> Search(SearchSpecification specification);
    }
}
