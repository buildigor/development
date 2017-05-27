using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Contracts;
using ATS.ExtensionLibArgs;

namespace ATS
{
    public class AutomaticTelephoneExchange
    {
        private readonly IList<CallInfo> _callInfoList;
        private readonly IDictionary<int, Tuple<Port, IContract>> _usersData;

        public AutomaticTelephoneExchange()
        {
            _callInfoList = new List<CallInfo>();
            _usersData = new Dictionary<int, Tuple<Port, IContract>>();
        }

        public Terminal GeTerminal(IContract terminal)
        {
            Port port = new Port();
            port.AnswerEvent += port_AnswerEvent;
            port.CallEvent += port_CallEvent;
            port.EndCallEvent += port_EndCallEvent;
            _usersData.Add(terminal.Number, new Tuple<Port, IContract>(port, terminal));
            return new Terminal(terminal.Number,port);
        }

        void port_AnswerEvent(object sender, ICallEventArgs e)
        {
            throw new NotImplementedException();
        }

        void port_EndCallEvent(object sender, ICallEventArgs e)
        {
            throw new NotImplementedException();
        }

        void port_CallEvent(object sender, ICallEventArgs e)
        {
            if (_usersData.ContainsKey(e.TargetPhoneNumber))
            {
                if (e is CallEventArgs)
                {
                    _callInfoList.Add(new CallInfo(e.PhoneNumber,e.TargetPhoneNumber,DateTime.Now));
                    var port = _usersData[e.PhoneNumber].Item1;
                    port.IncomingCall(e.PhoneNumber,e.TargetPhoneNumber);

                }
            }
        }

        public IList<CallInfo> GetCallsInfo()
        {
            return _callInfoList;
        }
    }
}
