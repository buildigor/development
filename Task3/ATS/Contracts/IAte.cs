using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Enums;

namespace ATS.Contracts
{
 public interface IAte:IInfo<CallInfo>
    {
     Terminal GeTerminal(IContract contract);
     IContract RegisterContract(Subscriber.Subscriber subscriber, TariffType type);
    }
}
