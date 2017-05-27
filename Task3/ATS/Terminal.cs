using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Contracts;
using ATS.Enums;
using ATS.ExtensionLibArgs;

namespace ATS
{
  public  class Terminal:ITerminal
    {
      public int Number { get; private set; }
      private readonly Port _port;

      public Terminal(int number, Port port)
      {
          Number = number;
          _port = port;
      }
      public event EventHandler<CallEventArgs> CallEvent;
      public event EventHandler<AnswerEventArgs> AnswerEvent;
      public event EventHandler<EndCallEventArgs> EndCallEvent;

      protected virtual void OnCallEvent(int targetNumber)
      {
          var handler = CallEvent;
          if (handler != null) handler(this, new CallEventArgs(Number, targetNumber));
      }

      protected virtual void OnAnswerEvent(int targetNumber, CallState state)
      {
          var handler = AnswerEvent;
          if (handler != null) handler(this,new AnswerEventArgs(Number,targetNumber,state));
      }

      protected virtual void OnEndCallEvent()
      {
          var handler = EndCallEvent;
          if (handler != null) handler(this, new EndCallEventArgs(Number));
      }

      public void ConnectToPort()
      {
          if (_port.ConnectToPort(this))
          {
              _port.CallPortEvent += IncomingCall;
          }
          
      }

      public void Call(int targetNumber)
      {
          OnCallEvent(targetNumber);
      }

      public void AnswerToCall(int targetNumber, CallState state)
      {
          OnAnswerEvent(targetNumber,state);
      }

      public void EndCall()
      {
          OnEndCallEvent();
      }

      public void IncomingCall(object sender, CallEventArgs callEventArgs)
      {
          bool k = true;
          Console.WriteLine("Call from number: {0} to number: {1}",callEventArgs.PhoneNumber,callEventArgs.TargetPhoneNumber);
          while (k)
          {
              Console.WriteLine("Answer? Y/N");
              char f = Console.ReadKey().KeyChar;
              if (f=='Y'||f=='y')
              {
                  k = false;
                  AnswerToCall(callEventArgs.PhoneNumber,CallState.Answered);
              }
              else if (f == 'N' || f == 'n')
              {
                  k = false;
                  EndCall();
              }
              else
              {
                  Console.WriteLine();
              }
          }
      }
    }
}
