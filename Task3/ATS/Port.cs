using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Enums;
using ATS.ExtensionLibArgs;

namespace ATS
{
    public class Port
    {
        public PortState PortState;

        public Port()
        {
            PortState = PortState.Disconnect;
        }

        public event EventHandler<CallEventArgs> CallEvent;
        public event EventHandler<AnswerEventArgs> AnswerEvent;
        public event EventHandler<EndCallEventArgs> EndCallEvent;
        public event EventHandler<CallEventArgs> CallPortEvent;
        public event EventHandler<AnswerEventArgs> AnswerPortEvent;

        public bool ConnectToPort(Terminal terminal)
        {
            if (PortState != PortState.Disconnect) return true;
            PortState = PortState.Connect;
            terminal.AnswerEvent += terminal_AnswerEvent;
            terminal.CallEvent += terminal_CallEvent;
            terminal.EndCallEvent += terminal_EndCallEvent;
            return true;
        }

        public bool DisconnectFromPort(Terminal terminal)
        {
            if (PortState != PortState.Connect) return false;
            PortState = PortState.Disconnect;
            terminal.AnswerEvent -= terminal_AnswerEvent;
            terminal.CallEvent -= terminal_CallEvent;
            terminal.EndCallEvent -= terminal_EndCallEvent;
            return false;
        }

        public bool InCallPort(Terminal terminal)
        {
            if (PortState == PortState.InCall) return false;
            PortState = PortState.InCall;
            terminal.AnswerEvent -= terminal_AnswerEvent;
            terminal.CallEvent -= terminal_CallEvent;
            terminal.EndCallEvent -= terminal_EndCallEvent;
            return false;
        }

        void terminal_EndCallEvent(object sender, EndCallEventArgs e)
        {
            OnEndCallEvent(e.PhoneNumber);
        }

        void terminal_CallEvent(object sender, CallEventArgs e)
        {
            OnCallEvent(e.PhoneNumber, e.TargetPhoneNumber);
        }

        void terminal_AnswerEvent(object sender, AnswerEventArgs e)
        {
            OnAnswerEvent(e.PhoneNumber, e.TargetPhoneNumber, e.CallState);
        }

        protected virtual void OnCallEvent(int number, int targetNumber)
        {
            var handler = CallEvent;
            if (handler != null) handler(this, new CallEventArgs(number, targetNumber));
        }

        protected virtual void OnAnswerEvent(int number, int targetNumber, CallState callState)
        {
            var handler = AnswerEvent;
            if (handler != null) handler(this, new AnswerEventArgs(number, targetNumber, callState));
        }

        protected virtual void OnEndCallEvent(int number)
        {
            var handler = EndCallEvent;
            if (handler != null) handler(this, new EndCallEventArgs(number));
        }

        protected virtual void OnCallPortEvent(int number, int targetNumber)
        {
            var handler = CallPortEvent;
            if (handler != null) handler(this, new CallEventArgs(number, targetNumber));
        }

        protected virtual void OnAnswerPortEvent(int number, int targetNumber, CallState callState)
        {
            var handler = AnswerPortEvent;
            if (handler != null) handler(this, new AnswerEventArgs(number, targetNumber, callState));
        }
        public void IncomingCall(int number, int targetNumber)
        {
            OnCallPortEvent(number, targetNumber);
        }
        public void AnswerCall(int number, int targetNumber, CallState state)
        {
            OnAnswerPortEvent(number, targetNumber, state);
        }
        public void EndCall(int number)
        {
            Console.WriteLine("Terminal with number: {0}, have rejected call", number); 
        }
    }
}
