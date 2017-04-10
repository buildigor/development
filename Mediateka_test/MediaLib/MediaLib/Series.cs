using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLib
{
   public class Series
    {
       public List<ISerial> Serials { get; protected set; }

       public Series()
       {
           Serials = new List<ISerial>();
       }
       public Series(List<ISerial> serials)
       {
           Serials = serials;
       }

       public void AddContentToSerial(ISerial serials)
       {
            Serials.Add(serials);
       }

       public void DeleteContentFromSerial(ISerial serials)
       {
           Serials.Remove(serials);
       }
       public string ShowAll()
       {
           return Serials.Aggregate<ISerial, string>(null, (current, mediatekaElement) => current + ("Serials: "+mediatekaElement.Id + " " + mediatekaElement.Name + "\n"));
       }
    }
}
