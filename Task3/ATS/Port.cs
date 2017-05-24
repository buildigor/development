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

  }
}
