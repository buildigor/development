using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MediaLib
{
  public  class Disk
  {
      
      public List<IDisc> DiscsElements { get; private set; }
      int _count = 20;


      public Disk()
      {
          DiscsElements=new List<IDisc>();
      }
      public Disk(List<IDisc> discelements )
      {
          DiscsElements = discelements;
      }
      public string AddToDisk(IDisc discelements)
      {
          DiscsElements.Add(discelements);
          if (DiscsElements.Count>_count)
          {
              return "On disk may be saved <20 elements";
          }
          return "On disk saved " + DiscsElements.Count;

      }

      public string ShowAll()
      {
          return DiscsElements.Aggregate<IDisc, string>(null, (current, mediatekaElement) => current + ("Disk: "+mediatekaElement.Id + " " + mediatekaElement.Name + "\n"));
      }

      public void Play()
      {
          throw new NotImplementedException();
      }
  }
}
