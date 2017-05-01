using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.Classes
{
    public abstract class Gift:IGift
    {
        public abstract void Add(ISweets sweets);
        public abstract void Remove(ISweets sweets);
        public virtual IEnumerable<ISweets> GetAllSweets()
        { return new List<ISweets>(); }

        public virtual IEnumerable<Candy> FindCandies(double minSugarCount, double maxSugarCount)
        { return new List<Candy>(); }

        public virtual IEnumerable<ISweets> FindSweets(double minSugarCount, double maxSugarCount)
        { return new List<ISweets>(); }

        public virtual IEnumerable<Candy> OrderCandyBy<TR>(Func<ISweets, TR> comparerFunc)
        { return new List<Candy>(); }

        public virtual IEnumerable<ISweets> OrderSweetsBy<TR>(Func<ISweets, TR> comparerFunc)
        { return new List<Candy>(); }


        public virtual IEnumerator<ISweets> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator  IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public double GiftWeight { get; protected set; }
    }
}
