using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.SpecificationForSearch
{
   public class DateSpecification:ISellingSpecification
   {
       private readonly DateTime _dateTime;

       public DateSpecification(DateTime dateTime)
       {
           _dateTime = dateTime;
       }
       public IEnumerable<SellingModel> SatisfiedBy(IEnumerable<SellingModel> content)
       {
           return !(_dateTime == default(DateTime))
               ? content.Where(x => x.Date.ToShortDateString() == _dateTime.ToShortDateString()):content;
       }
    }
}
