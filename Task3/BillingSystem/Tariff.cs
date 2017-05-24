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
            TariffType = tariffType;
            switch (TariffType)
            {
                    case TariffType.Mini:
                    CostOfMonth = 20;
                    CostCallPerMinute = 0.5;
                    break;
                    case TariffType.Light:
                    CostOfMonth = 30;
                    CostCallPerMinute = 0.3;
                    break;
                    case TariffType.Ultra:
                    CostOfMonth = 40;
                    CostCallPerMinute = 0.1;
                    break;
                default:
                    CostOfMonth = 50;
                    CostCallPerMinute = 0;
                    break;
            }
        }
    }
}
