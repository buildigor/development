using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLib
{
   public class Selection
    {
       public List<ISelection> Selections { get; protected set; }

       public Selection()
       {
           Selections = new List<ISelection>();
       }

       public Selection(List<ISelection> selection)
       {
           Selections = selection;
       }

       public void AddToSelection(ISelection selection)
       {
           Selections.Add(selection);
       }

       public void SortSelection(ISelection selection)
       {
           Selections.Sort();
       }

       public void DeleteFromSelection(ISelection selection)
       {
           Selections.Remove(selection);
       }
    }
}
