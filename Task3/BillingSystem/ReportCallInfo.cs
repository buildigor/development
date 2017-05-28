using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Enums;

namespace BillingSystem
{
  public  class ReportCallInfo
    {
      public CallType CallType { get; private set; }
      public int Number { get; private set; }
      public int TargetNumber { get; private set; }
      public DateTime Date { get; private set; }
      public DateTime Time { get; private set; }
      public double Cost { get; private set; }
      public ReportCallInfo(CallType callType,int number,int targetNumber, DateTime date, DateTime time, double cost)
      {
          Number = number;
          TargetNumber = targetNumber;
          Date = date;
          Time = time;
          Cost = cost;
          CallType = callType;
      }
    }
}
