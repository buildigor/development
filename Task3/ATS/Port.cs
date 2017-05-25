using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Enums;

namespace ATS
{
  public  class Port
  {
      public PortState PortState;

      public Port()
      {
          PortState=PortState.Disconnect;
      }

      public event EventHandler CallEvent;
      public event EventHandler AnswerEvent;
      public event EventHandler EndCallEvent;

      public bool ConnectToPort(Terminal terminal)
      {
          if (PortState==PortState.Disconnect)
          {
              PortState=PortState.Connect;
              terminal.AnswerEvent += terminal_AnswerEvent;
              terminal.CallEvent += terminal_CallEvent;
              terminal.EndCallEvent += terminal_EndCallEvent;
          }
          return true;
      }
      public bool DisconnectFromPort(Terminal terminal)
      {
          if (PortState == PortState.Connect)
          {
              PortState = PortState.Disconnect;
              terminal.AnswerEvent -= terminal_AnswerEvent;
              terminal.CallEvent -= terminal_CallEvent;
              terminal.EndCallEvent -= terminal_EndCallEvent;
          }
          return false;
      }
      public bool InCallPort(Terminal terminal)
      {
          if (PortState != PortState.InCall)
          {
              PortState = PortState.InCall;
              terminal.AnswerEvent -= terminal_AnswerEvent;
              terminal.CallEvent -= terminal_CallEvent;
              terminal.EndCallEvent -= terminal_EndCallEvent;
          }
          return false;
      }

      void terminal_EndCallEvent(object sender, EventArgs e)
      {
          throw new NotImplementedException();
      }

      void terminal_CallEvent(object sender, EventArgs e)
      {
          throw new NotImplementedException();
      }

      void terminal_AnswerEvent(object sender, EventArgs e)
      {
          throw new NotImplementedException();
      }
     
  }
}
