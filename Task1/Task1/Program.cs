using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task1.Classes;
using Task1.Interfaces;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            LollipopCandy lollipop = new LollipopCandy("Dushes lollipopCandy", 2, 1.5, "circle", "green");
            ChocolateCandy chocolateCandy = new ChocolateCandy("Chocolate Candy", 5, 3, "rectangular", 4);
            MilkCandy milkCandy = new MilkCandy("Korovka", 3, 2, "rectangular",1);
            FrutCandy frutCandy = new FrutCandy("Abricosovye Candy",2.4,1.2,"elliptical","apricot");
            StickOfConfectionery stickOfConfectioneryS = new StickOfConfectionery("Snikers stickOfConfectionery", 35, 27, 15);
            StickOfConfectionery stickOfConfectioneryM = new StickOfConfectionery("Mars stickOfConfectionery", 25, 15, 20);
            Wafer wafer = new Wafer("Chernomorskie wafers", 6, 3, 2);
            NewYearsGift gift = new NewYearsGift
            {
                lollipop,chocolateCandy,stickOfConfectioneryM,stickOfConfectioneryS,wafer,milkCandy,frutCandy
            };
            Package package = new Package("cellophane","green", gift);
            
            Console.WriteLine("*********************Total Weight Candies******");
            Console.WriteLine(gift.CandiesWeight);
            Console.WriteLine("*********************Total Weight NewYearsGift******");
            Console.WriteLine(gift.GiftWeight);
            Console.WriteLine("*********************All Sweets*********************");
            Console.WriteLine(gift.GetAllCandies().ListAllToString());
            Console.WriteLine("*********************Finded Candyes******************");
            Console.WriteLine(gift.FindCandies(1, 7).ListCandyToString());
            Console.WriteLine("*********************Ordered Candyes*****************");
            Console.WriteLine(gift.OrderBy(x => x.Name).ListCandyToString());
            Console.WriteLine(gift.GetType().Name + " in "+package.Material+" package " + package.Color);
            Console.ReadLine();
        }
    }
}
