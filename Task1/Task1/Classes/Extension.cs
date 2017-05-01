using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.Classes
{
   public static class Extension
    {
        public static string ListCandyToString(this IEnumerable<Candy> list)
        {
            return list.Aggregate<ISweets, string>(null, (current, sweets) => current + (sweets.Name + "\n"));
        }

       public static string ListAllToString(this IEnumerable<ISweets> list)
        {

             return list.Aggregate<ISweets, string>(null, (current, sweets) => current + (sweets.Name + "\n"));
        }
    }
}
