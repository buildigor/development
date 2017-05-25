using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.ExtensionLibArgs
{
  public class EndCallEventArgs:EventArgs
    {
     public int PhoneNumber { get; private set; }
     public int TargetPhoneNumber { get; private set; }

      public EndCallEventArgs(int phoneNumber)
      {
          PhoneNumber = phoneNumber;
      }
    }
}
