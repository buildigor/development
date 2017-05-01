using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.Classes
{
    public class NewYearsGift : Gift
    {
        private readonly ICollection<ISweets> _sweets;

        public NewYearsGift()
        {
            _sweets = new List<ISweets>();
           
        }


        //public double GiftWeight { get; protected set; }
        public double CandiesWeight { get; protected set; }
        public double GiftCost { get; protected set; }
        public double CandiesCost { get; protected set; }

        public void Add(IEnumerable<ISweets> sweetses)
        {
            foreach (ISweets sweet in sweetses)
            {
                Add(sweet);
            }
        }
        public void Remove(IEnumerable<ISweets> sweetses)
        {
            foreach (ISweets sweetse in sweetses)
            {
                Remove(sweetse);
            }
        }
        public override void Add(ISweets sweets)
        {
            if (sweets == null)
            {
                throw new ArgumentNullException();
            }
            _sweets.Add(sweets);
            GiftWeight += sweets.Weight;
            GiftCost += sweets.Cost;
            if (!(sweets is Candy)) return;
            CandiesWeight += sweets.Weight;
            CandiesCost += sweets.Cost;
        }

        public override void Remove(ISweets sweets)
        {
            if (sweets == null)
            {
                throw new ArgumentNullException();
            }
            _sweets.Remove(sweets);
            GiftWeight -= sweets.Weight;
            GiftCost -= sweets.Cost;
            if (!(sweets is Candy)) return;
            CandiesWeight -= sweets.Weight;
            CandiesCost -= sweets.Cost;
        }

        public override IEnumerable<ISweets> GetAllSweets()
        {

            return _sweets.ToList();

        }
        public override IEnumerable<Candy> FindCandies(double minSugarCount, double maxSugarCount)
        {

            return _sweets.Where(x => x is Candy && x.Sugar >= minSugarCount && x.Sugar <= maxSugarCount).Select(a => (Candy)a).ToList();

        }

        public override IEnumerable<ISweets> FindSweets(double minSugarCount, double maxSugarCount)
        {

            return _sweets.Where(x => x.Sugar >= minSugarCount && x.Sugar <= maxSugarCount).ToList();

        }

        public override IEnumerable<Candy> OrderCandyBy<TR>(Func<ISweets, TR> comparerFunc)
        {

            return _sweets.OrderBy(comparerFunc).OfType<Candy>().ToList();

        }

        public override IEnumerable<ISweets> OrderSweetsBy<TR>(Func<ISweets, TR> comparerFunc)
        {
            return _sweets.OrderBy(comparerFunc).ToList();
        }
        

        
    }
}
