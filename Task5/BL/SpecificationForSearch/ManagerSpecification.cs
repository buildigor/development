using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.SpecificationForSearch
{
   public class ManagerSpecification:ISellingSpecification
   {
       private readonly string _managerName;

       public ManagerSpecification(string managerName)
       {
           _managerName = managerName;
       }
       public IEnumerable<SellingModel> SatisfiedBy(IEnumerable<SellingModel> content)
       {
           return !String.IsNullOrEmpty(_managerName) ? content.Where(x => x.ManagerName == _managerName) : content;
       }
   }
}
