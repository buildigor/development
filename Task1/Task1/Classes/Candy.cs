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
        public string Name { get { return _name; } }
        public double Weight { get { return _weight; } }
        public double Sugar { get { return _sugar; } }

        public string Form { get { return _form; } }

        protected Candy(string name, double weight, double sugar, string form)
        {
            _name = name;
            _weight = weight;
            _sugar = sugar;
            _form = form;

        }
    }
}
