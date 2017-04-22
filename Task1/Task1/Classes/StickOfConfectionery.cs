using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.Classes
{
    public class StickOfConfectionery : ISweets
    {
        private readonly string _name;
        private readonly double _weight;
        private readonly double _sugar;
        private readonly double _hazelnut;

        public string Name
        {
            get { return _name; }
        }

        public double Weight
        {
            get { return _weight; }
        }

        public double Sugar
        {
            get { return _sugar; }
        }

        public double Hazelnut
        {
            get { return _hazelnut; }
        }

        public StickOfConfectionery(string name, double weight, double sugarcount, double hazelnut)
        {
            _name = name;
            _weight = weight;
            _sugar = sugarcount;
            _hazelnut = hazelnut;
        }
    }
}
