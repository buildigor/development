using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLib
{
    public abstract class Item
    {
        public string Name { get; set; }

        protected Item(string name)
        {
            Name = name;
        }
    }
}
