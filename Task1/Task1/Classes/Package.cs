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
        private  Gift _newYearsGift;

        public string Color { get; private set; }
        public string Material { get; set; }

        public Package(string material,string color, Gift newYearsGift)
        {
            Material = material;
            Color = color;
            _newYearsGift = newYearsGift;
            
        }
    }
}
