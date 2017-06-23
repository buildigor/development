using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.SpecificationForSearch
{
   public interface ISpecification<T>
   {
       IEnumerable<T> SatisfiedBy(IEnumerable<T> content);
   }
}
