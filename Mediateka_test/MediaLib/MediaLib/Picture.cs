using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLib
{
   public class Picture:LinkItem,IDisc,ISerial
   {
       public int Id { get; private set; }

       public new string Name
        {
            get { return "Picture: " + base.Name; }
        }
        
        public Picture(int id,string name, string url) : base(name, url)
        {
            Id = id;
        }

       public string Play()
       {
           throw new NotImplementedException();
       }
   }
}
