using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Enums;
using ATS.Subscriber;

namespace ATS.Contracts
{
  public  interface IContract
    {
      int Number { get; }
      Subscriber.Subscriber Subscriber { get; }
      Tariff Tariff { get; }
      double Ballance { get; }
      bool ChangeTariff(TariffType tariffType);
      void ReplenishmentOfBalance(double money);
      void Debit(double money);
    }
}
