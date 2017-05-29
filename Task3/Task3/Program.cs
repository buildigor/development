using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ATS;
using ATS.Contracts;
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
            IAte automaticTelephoneExchange = new AutomaticTelephoneExchange();
            IContract contract1 = new Contract(new Subscriber("Ivan", "Ivanov"), TariffType.Light);
            Thread.Sleep(1000);
            IContract contract2 = new Contract(new Subscriber("Petr", "Petrov"), TariffType.Mini);
            Thread.Sleep(1000);
            IContract contract3 = new Contract(new Subscriber("Mihail", "Mihailov"), TariffType.Ultra);
            var t1 = automaticTelephoneExchange.GeTerminal(contract1);
            var t2 = automaticTelephoneExchange.GeTerminal(contract2);
            var t3 = automaticTelephoneExchange.GeTerminal(contract3);
            t1.ConnectToPort();
            t2.ConnectToPort();
            t3.ConnectToPort();
            t1.Call(t1.Number);
            Thread.Sleep(5000);
            //t2.DisconnectFromPort();
            t1.Call(t2.Number);
            Thread.Sleep(5000);
            t1.EndCall();
            t3.Call(t1.Number);
            Thread.Sleep(5000);
            t3.EndCall();
            t2.Call(t1.Number);
            Thread.Sleep(5000);
            t2.EndCall();
            ReportProvider reportProvider = new ReportProvider();
            Billing billing = new Billing(automaticTelephoneExchange);
            foreach (
                var item in reportProvider.SortCallsByType(billing.GetReport(t1.Number), TypeSortCalls.SortByCallType))
            {
                Console.WriteLine(
                    "Report for number: {5}"
                    + Environment.NewLine + " Type: {0} |"
                    + Environment.NewLine + " Date: {1} |"
                    + Environment.NewLine + " Duration: {2} |"
                    + Environment.NewLine + " Cost: {3} |" 
                    + Environment.NewLine + " Target Telephone number: {4}",
                    item.CallType, item.Date, item.Time.ToString("mm:ss"), item.Cost, item.TargetNumber, item.Number);
            }
            Console.ReadLine();
        }
    }
}
