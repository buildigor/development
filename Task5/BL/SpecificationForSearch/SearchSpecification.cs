using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.SpecificationForSearch
{
   public class SearchSpecification:ISellingSpecification
    {
       public string ManagerName { get; set; }
       public string ClientName { get; set; }
       public string ProductName { get; set; }
       public DateTime Date { get; set; }
       public IEnumerable<SellingModel> SatisfiedBy(IEnumerable<SellingModel> content)
       {
           var search = new ManagerSpecification(ManagerName);
           content = search.SatisfiedBy(content);
           content = new ClientSpecification(ClientName).SatisfiedBy(content);
           content = new ProductSpecification(ProductName).SatisfiedBy(content);
           return new DateSpecification(Date).SatisfiedBy(content);
       }
    }
}
