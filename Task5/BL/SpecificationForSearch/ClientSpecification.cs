using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.SpecificationForSearch
{
  public class ClientSpecification:ISellingSpecification
  {
      private readonly string _clientName;

      public ClientSpecification(string clientName)
      {
          _clientName = clientName;
      }
      public IEnumerable<SellingModel> SatisfiedBy(IEnumerable<SellingModel> content)
      {
          return !String.IsNullOrEmpty(_clientName) ? content.Where(x => x.ClientName == _clientName) : content;
      }
    }
}
