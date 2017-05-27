using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Contracts
{
    public interface ITerminal
    {
        int Number { get; }
        void Call(int targetNumber);
        void ConnectToPort();
        void EndCall();
    }
}
