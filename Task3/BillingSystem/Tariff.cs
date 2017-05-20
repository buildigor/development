using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Contracts;
using BillingSystem.Enums;

namespace BillingSystem
{
    public class Tariff:ITariff
    {
        public double CostOfMonth { get; private set; }
        public double CostCallPerMinute { get; private set; }
        public TariffType TariffType;

        public Tariff(TariffType tariffType)
        {
            
        }
    }
}
