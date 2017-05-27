using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Contracts;

namespace ATS.ExtensionLibArgs
{
    public class CallEventArgs : EventArgs, ICallEventArgs
    {
     public int PhoneNumber { get; private set; }
     public int TargetPhoneNumber { get; private set; }
     public CallEventArgs(int phoneNumber, int targetPhoneNumber)
     {
         PhoneNumber = phoneNumber;
         TargetPhoneNumber = targetPhoneNumber;
     }
    }
}
