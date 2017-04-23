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
            LollipopCandy lollipop = new LollipopCandy("Dushes lollipopCandy", 2, 1.5, "circle", "green",5);
            ChocolateCandy chocolateCandy = new ChocolateCandy("Chocolate Candy", 5, 3, "rectangular", 4,10);
            MilkCandy milkCandy = new MilkCandy("Korovka", 3, 2, "rectangular",1,7);
            FrutCandy frutCandy = new FrutCandy("Abricosovye Candy",2.4,1.2,"elliptical","apricot",6);
            StickOfConfectionery stickOfConfectioneryS = new StickOfConfectionery("Snikers stickOfConfectionery", 35, 27, 15,15);
            StickOfConfectionery stickOfConfectioneryM = new StickOfConfectionery("Mars stickOfConfectionery", 25, 15, 20,13);
            Wafer wafer = new Wafer("Chernomorskie wafers", 6, 3, 2,11);
         
            NewYearsGift gift = new NewYearsGift
            {
                lollipop,chocolateCandy,stickOfConfectioneryM,stickOfConfectioneryS,wafer,milkCandy,frutCandy
            };
            Package package = new Package("cellophane","green", gift);
            
            Console.WriteLine("*********************Total Weight Candies************");
            Console.WriteLine(gift.CandiesWeight);
            Console.WriteLine("*********************Total Cost Candies**************");
            Console.WriteLine(gift.CandiesCost);
            Console.WriteLine("*********************Total Weight NewYearsGift*******");
            Console.WriteLine(gift.GiftWeight);
            Console.WriteLine("*********************Total Cost NewYearsGift*********");
            Console.WriteLine(gift.GiftCost);
            Console.WriteLine("*********************All Sweets**********************");
            Console.WriteLine(gift.GetAllCandies().ListAllToString());
            Console.WriteLine("*********************Finded Candyes******************");
            Console.WriteLine(gift.FindCandies(1, 7).ListCandyToString());
            Console.WriteLine("*********************Ordered Candyes By Name*********");
            Console.WriteLine(gift.OrderBy(x => x.Name).ListCandyToString());
            Console.WriteLine(gift.GetType().Name + " in "+package.Material+" package " + package.Color);
            Console.ReadLine();
        }
    }
}
