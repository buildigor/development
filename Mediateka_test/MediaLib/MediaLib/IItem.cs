using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLib
{
    public interface IItem
    {
        int Id { get; }
        string Name { get; }
    }
}
