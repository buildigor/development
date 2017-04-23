using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Interfaces
{
   public interface IPackage
   {
       string Color { get; }
       string Material { get; set; }
   }
}
