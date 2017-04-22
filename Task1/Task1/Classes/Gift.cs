using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.Classes
{
    public abstract class Gift
    {
        public virtual void Add(ISweets sweets)
        { }
        public virtual IEnumerable<ISweets> GetAllCandies()
        { return new List<ISweets>(); }

        public virtual IEnumerable<Candy> FindCandies(double minSugarCount, double maxSugarCount)
        { return new List<Candy>(); }

        public virtual IEnumerable<Candy> OrderBy<R>(Func<ISweets, R> comparerFunc)
        { return new List<Candy>(); }
    }
}
