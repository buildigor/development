using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes
{
    class FrutCandy:Candy
    {
        private readonly string _jelly;
        public string Jelly { get { return _jelly; } }
        public FrutCandy(string name, double weight, double sugar, string form,string jelly) : base(name, weight, sugar, form)
        {
            _jelly = jelly;
        }
    }
}
