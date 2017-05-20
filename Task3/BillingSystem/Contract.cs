using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Contracts;

namespace BillingSystem
{
   public class Contract:IContract
    {
       public int Number { get; private set; }
       public Subscriber Subscriber { get; private set; }
       public Tariff Tariff { get; private set; }
       public DateTime LastDateUpdateTariff;
       public bool ChangeTariff()
       {
           throw new NotImplementedException();
       }

       
    }
}
