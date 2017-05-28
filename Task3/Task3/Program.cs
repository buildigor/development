using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ATS;
using ATS.Enums;
using ATS.Subscriber;
using BillingSystem;
using BillingSystem.Enums;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportProvider reportProvider = new ReportProvider();
            Subscriber subscriber = new Subscriber("Ivan","Ivanov");
            Contract contract = new Contract(subscriber,TariffType.Mini);
            Thread.Sleep(2000);
            Subscriber subscriber1 = new Subscriber("Petr", "Petrov");
            Contract contract1 = new Contract(subscriber1, TariffType.Light);
            Console.WriteLine(contract.Number);
            Console.WriteLine(contract1.Number);
            AutomaticTelephoneExchange automaticTelephoneExchange = new AutomaticTelephoneExchange();
            var t1 = automaticTelephoneExchange.GeTerminal(contract);
            var t2 = automaticTelephoneExchange.GeTerminal(contract1);
            t1.ConnectToPort();
            t1.Call(t2.Number);
            Thread.Sleep(5000);
            t1.EndCall();
            Billing billing = new Billing(automaticTelephoneExchange);
            foreach (var item in reportProvider.SortCallsByType(billing.GetReport(t1.Number), TypeSortCalls.SortByCallType))
            {
                Console.WriteLine("Calls:\n Type {0} |\n Date: {1} |\n Duration: {2} | Cost: {3} | Telephone number: {4}",
                    item.CallType, item.Date, item.Time.ToString("mm:ss"), item.Cost, item.Number);
            }
            Console.ReadLine();



        }
    }
}
