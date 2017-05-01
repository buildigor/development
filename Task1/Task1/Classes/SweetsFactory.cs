using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.Classes
{
    public class SweetsFactory
    {
        
      public ISweets CreateChocolateCandy(string name, double weight, double sugar, string form, double cacaocount, double cost)
      {
          return  new ChocolateCandy(name,weight,sugar,form,cacaocount,cost);
      }
      public ISweets CreateFrutCandy(string name, double weight, double sugar, string form, string jelly, double cost)
      {
          return new FrutCandy(name,weight,sugar,form,jelly,cost);
      }
      public ISweets CreateLollipopCandy(string name, double weight, double sugar, string form, string color, double cost)
      {
          return new LollipopCandy(name, weight, sugar, form, color, cost);
      }
      public ISweets CreateMilkCandy(string name, double weight, double sugar, string form, double milkcount, double cost)
      {
          return new MilkCandy(name, weight, sugar, form, milkcount, cost);
      }
      public ISweets CreateWafer(string name, double weight, double sugar, int waferCount, double cost)
      {
          return new Wafer(name, weight, sugar, waferCount, cost);
      }

      public ISweets CreateStickOfConfectionery(string name, double weight, double sugarcount, double hazelnut,
          double cost)
      {
          return  new StickOfConfectionery(name,weight,sugarcount,hazelnut,cost);
      }
    }
}
