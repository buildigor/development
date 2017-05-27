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
       private readonly Contract _contract;

       public Billing(IInfo<CallInfo> info, Contract contract)
       {
           _info = info;
           _contract = contract;
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
               var minutesOfCall = callInfo.EndCall.Minute - callInfo.BeginCall.Minute;
               var cost = minutesOfCall*_contract.Tariff.CostCallPerMinute;
               report.AddCallInfo(new ReportCallInfo(callType,number,callInfo.BeginCall,new DateTime((callInfo.EndCall-callInfo.BeginCall).Ticks),cost));
           }
           return report;
       }
   }
}
