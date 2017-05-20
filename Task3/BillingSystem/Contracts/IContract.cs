using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Contracts
{
  public  interface IContract
    {
      int Number { get; }
      Subscriber Subscriber { get; }
      Tariff Tariff { get; }
      bool ChangeTariff();
    }
}
