using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Contracts
{
   public interface ICallEventArgs
    {
        int TelephoneNumber { get; }
        int TargetTelephoneNumber { get; }
    }
}
