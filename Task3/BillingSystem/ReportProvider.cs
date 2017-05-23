using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Enums;

namespace BillingSystem
{
   public class ReportProvider
    {
       public void Render(Report report)
       {
           foreach (var callInfo in report.GetCallInfo())
           {
               Console.WriteLine("Calls:" + Environment.NewLine + " Type {0} |" + Environment.NewLine + " Date: {1} |" + Environment.NewLine + " Duration: {2} | Cost: {3} | Telephone number: {4}"
                   ,callInfo.CallType,callInfo.Date,callInfo.Time.ToString("mm:ss"),callInfo.Cost,callInfo.Number);
           }
       }

       public IEnumerable<ReportCallInfo> SortCallsByType(Report report, TypeSortCalls sortCalls)
       {
           switch (sortCalls)
           {
               case TypeSortCalls.SortByCallType:
                   return report.GetCallInfo().OrderBy(x => x.CallType).ToList();
               case TypeSortCalls.SortByCost:
                   return report.GetCallInfo().OrderBy(x => x.Cost).ToList();
               case TypeSortCalls.SortByDate:
                   return report.GetCallInfo().OrderBy(x => x.Date).ToList();
               case TypeSortCalls.SortByNumber:
                   return report.GetCallInfo().OrderBy(x => x.Number).ToList();
               default:
                   return report.GetCallInfo();
           }
       }
    }
}
