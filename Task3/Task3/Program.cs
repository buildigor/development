using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS;
using BillingSystem;
using BillingSystem.Enums;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Subscriber subscriber = new Subscriber("Ivan","Ivanov");
            Contract contract = new Contract(subscriber,TariffType.Mini);
            Console.WriteLine(contract.Number);
            AutomaticTelephoneExchange automaticTelephoneExchange = new AutomaticTelephoneExchange();
            var t1 = automaticTelephoneExchange.GeTerminal(25365625);


        }
    }
}
