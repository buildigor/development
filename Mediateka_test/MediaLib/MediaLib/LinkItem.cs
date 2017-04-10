using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLib
{
   public abstract class LinkItem:Item
    {
       public string Url { get; private set; }
       protected LinkItem(string name,string url) : base(name)
       {
           Url = url;
       }

       
    }
}
