using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Contracts;

namespace ATS
{
    public class AutomaticTelephoneExchange
    {
        private readonly IList<CallInfo> _callInfoList;
        private readonly IDictionary<int, Port> _usersData;

        public AutomaticTelephoneExchange()
        {
            _callInfoList = new List<CallInfo>();
            _usersData = new Dictionary<int, Port>();
        }

        public Terminal GeTerminal(int number)
        {
            Port port = new Port();
            port.AnswerEvent += port_AnswerEvent;
            port.CallEvent += port_CallEvent;
            port.EndCallEvent += port_EndCallEvent;
            _usersData.Add(number,port);
            return new Terminal(number,port);
        }

        void port_AnswerEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void port_EndCallEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void port_CallEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public IList<CallInfo> GetCallsInfo()
        {
            return _callInfoList;
        }
    }
}
