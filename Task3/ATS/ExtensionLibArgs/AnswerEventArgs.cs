using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Contracts;
using ATS.Enums;

namespace ATS.ExtensionLibArgs
{
    public class AnswerEventArgs : EventArgs, ICallEventArgs
    {
       public int PhoneNumber { get; private set; }
       public int TargetPhoneNumber { get; private set; }
       public CallState CallState;

       public AnswerEventArgs(int phoneNumber, int targetPhoneNumber,CallState callState)
       {
           PhoneNumber = phoneNumber;
           TargetPhoneNumber = targetPhoneNumber;
           CallState = callState;
       }
    }
}
