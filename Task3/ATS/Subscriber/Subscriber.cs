using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Subscriber
{
  public  class Subscriber
    {
      public string FirstName { get; private set; }
      public string Lastname { get; private set; }

      public Subscriber(string firstName, string lastname)
      {
          FirstName = firstName;
          Lastname = lastname;
      }
    }
}
