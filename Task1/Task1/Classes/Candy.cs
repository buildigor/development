using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.Classes
{
    public abstract class Candy : ISweets
    {
        private readonly string _name;
        private readonly double _weight;
        private readonly double _sugar;
        private readonly string _form;
        private readonly double _cost;
        public string Name { get { return _name; } }
        public double Weight { get { return _weight; } }
        public double Sugar { get { return _sugar; } }

        public string Form { get { return _form; } }
        public double Cost { get { return _cost; } }
        protected Candy(string name, double weight, double sugar, string form, double cost)
        {
            _name = name;
            _weight = weight;
            _sugar = sugar;
            _form = form;
            _cost = cost;
        }

        
    }
}
