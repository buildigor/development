using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes
{
    public class ChocolateCandy : Candy
    {
        private readonly double _cacaocount;
        public double CacaoCount { get { return _cacaocount; } }
        public ChocolateCandy(string name, double weight, double sugar, string form, double cacaocount,double cost)
            : base(name, weight, sugar, form,cost)
        {
            _cacaocount = cacaocount;
        }
    }
}
