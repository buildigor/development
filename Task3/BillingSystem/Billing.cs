using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS;
using ATS.Contracts;
using ATS.Subscriber;
using BillingSystem.Enums;

namespace BillingSystem
{
   public class Billing
   {
       private readonly IInfo<CallInfo> _info;
       public Billing(IInfo<CallInfo> info)
       {
           _info = info;
       }

       public Report GetReport(int telNumber)
       {
           var report = new Report();
           var calls = _info.GetInfoList().Where(x => x.Number == telNumber || x.TargetNumber == telNumber).ToList();
           foreach (CallInfo callInfo in calls)
           {
               CallType callType;
               int number;
               if (callInfo.Number==telNumber)
               {
                   callType=CallType.OutgoingCall;
                   number = callInfo.TargetNumber;
               }
               else
               {
                   callType=CallType.IncomingCall;
                   number = callInfo.Number;
               }
               report.AddCallInfo(new ReportCallInfo(callType,number,callInfo.BeginCall,new DateTime((callInfo.EndCall-callInfo.BeginCall).Ticks),callInfo.Cost));
           }
           return report;
       }
   }
}
