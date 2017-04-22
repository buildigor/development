using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.Classes
{
    public class NewYearsGift : Gift, IGift
    {
        private readonly ICollection<ISweets> _candies = new List<ISweets>();

        public double GiftWeight { get; protected set; }
        public double CandiesWeight { get; protected set; }

        public override void Add(ISweets sweets)
        {
            if (sweets == null)
            {
                throw new ArgumentNullException();
            }
            _candies.Add(sweets);
            GiftWeight += sweets.Weight;
            if (sweets is Candy)
            {
                CandiesWeight += sweets.Weight;
            }

        }
        public override IEnumerable<ISweets> GetAllCandies()
        {

            return _candies.ToList();

        }
        public override IEnumerable<Candy> FindCandies(double minSugarCount, double maxSugarCount)
        {

            return _candies.Where(x => x is Candy && x.Sugar >= minSugarCount && x.Sugar <= maxSugarCount).Select(a => (Candy)a).ToList();

        }

        public override IEnumerable<Candy> OrderBy<R>(Func<ISweets, R> comparerFunc)
        {

            return _candies.OrderBy(comparerFunc).OfType<Candy>().ToList();

        }
        public IEnumerator<ISweets> GetEnumerator()
        {
            return _candies.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
