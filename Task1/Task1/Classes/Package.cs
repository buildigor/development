using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.Classes
{
    public class Package : IPackage
    {
        private readonly Gift _newYearsGift;
        public string Color { get; private set; }
        public Package(string color, Gift newYearsGift)
        {
            _newYearsGift = newYearsGift;
            Color = color;
        }


    }
}
