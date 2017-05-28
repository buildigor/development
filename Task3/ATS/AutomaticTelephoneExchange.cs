using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Contracts;
using ATS.Enums;
using ATS.ExtensionLibArgs;
using ATS.Subscriber;

namespace ATS
{
    public class AutomaticTelephoneExchange : IAte
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
            return new Terminal(terminal.Number, port);
        }

        public IContract RegisterContract(Subscriber.Subscriber subscriber, TariffType type)
        {
           Contract contract = new Contract(subscriber,type);
            return contract;
        }

        void port_AnswerEvent(object sender, ICallEventArgs e)
        {
            if (e is AnswerEventArgs)
            {
                var answerArgs = (AnswerEventArgs) e;
                var callListFirst = _callInfoList.First(x => x.Number.Equals(answerArgs.PhoneNumber));
                var port = _usersData[callListFirst.Number].Item1;
                port.AnswerCall(answerArgs.PhoneNumber, answerArgs.TargetPhoneNumber,
                    answerArgs.CallState);
              //  _usersData[e.TargetPhoneNumber].Item1.AnswerCall(answerArgs.PhoneNumber, answerArgs.TargetPhoneNumber,
              //      answerArgs.CallState);

            }
        }

        void port_EndCallEvent(object sender, ICallEventArgs e)
        {
            if (e is EndCallEventArgs)
            {
                var args = (EndCallEventArgs) e;
                CallInfo info = _callInfoList.First(x => x.Number.Equals(args.PhoneNumber));
                info.EndCall = DateTime.Now;
                info.Cost = _usersData[info.Number].Item2.Tariff.CostCallPerMinute*
                                 (info.EndCall.Minute - info.BeginCall.Minute);
                _usersData[info.Number].Item2.Debit(info.Cost);
            }
        }

        void port_CallEvent(object sender, ICallEventArgs e)
        {
            if (_usersData.ContainsKey(e.TargetPhoneNumber))
            {
                if (e is CallEventArgs)
                {
                    if (_usersData[e.PhoneNumber].Item2.Ballance >=
                        _usersData[e.PhoneNumber].Item2.Tariff.CostCallPerMinute)
                    {
                        _callInfoList.Add(new CallInfo(e.PhoneNumber, e.TargetPhoneNumber, DateTime.Now));
                        var port = _usersData[e.PhoneNumber].Item1;
                        port.IncomingCall(e.PhoneNumber, e.TargetPhoneNumber);
                    }
                    else
                    {
                        Console.WriteLine("Terminal with number {0} is not enough money in the account!", e.PhoneNumber);
                    }

                }
            }
        }

        public IList<CallInfo> GetInfoList()
        {
            return _callInfoList;
        }
    }
}
