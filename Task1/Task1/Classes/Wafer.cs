using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.Classes
{
    public class Wafer : ISweets
    {
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public double Sugar { get; private set; }
        public int WaferCount { get; private set; }
        public double Cost { get; private set; }
        public Wafer(string name, double weight, double sugar, int waferCount, double cost)
        {
            Name = name;
            Weight = weight;
            Sugar = sugar;
            WaferCount = waferCount;
            Cost = cost;
        }

        
    }
}
