using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Enums;
using ATS.ExtensionLibArgs;

namespace ATS
{
  public  class Terminal
    {
      public int Number { get; private set; }
      private Port _port;

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
    }
}
