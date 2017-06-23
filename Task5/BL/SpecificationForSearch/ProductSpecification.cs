using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.SpecificationForSearch
{
   public class ProductSpecification:ISellingSpecification
   {
       private readonly string _productName;

       public ProductSpecification(string productName)
       {
           _productName = productName;
       }
       public IEnumerable<SellingModel> SatisfiedBy(IEnumerable<SellingModel> content)
       {
           return !String.IsNullOrEmpty(_productName) ? content.Where(x => x.ProductName == _productName) : content;
       }
    }
}
