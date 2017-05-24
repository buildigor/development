using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
