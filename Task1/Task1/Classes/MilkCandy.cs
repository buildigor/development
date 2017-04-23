using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes
{
   public class MilkCandy:Candy
   {
       private readonly double _milkcount ;
       public double MilkCount { get { return _milkcount; } }
       public MilkCandy(string name, double weight, double sugar, string form,double milkcount,double cost) : base(name, weight, sugar, form,cost)
       {
           _milkcount = milkcount;
       }
    }
}
