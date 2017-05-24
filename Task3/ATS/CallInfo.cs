using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
   public class CallInfo
    {
       public int Number { get; set; }
       public int TargetNumber { get; set; }
       public DateTime BeginCall { get; set; }
       public DateTime EndCall { get; set; }
      // public double Cost { get; set; }

       public CallInfo(int number, int targetNumber, DateTime beginCall)
       {
           Number = number;
           TargetNumber = targetNumber;
           BeginCall = beginCall;
       }
       
    }
}
