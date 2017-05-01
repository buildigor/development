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
           
            SweetsFactory factory = new SweetsFactory();
            ISweets lollipop = factory.CreateLollipopCandy("Dushes lollipopCandy", 2, 1.5, "circle", "green", 5);
            ISweets chocolateCandy = factory.CreateChocolateCandy("Chocolate Candy", 5, 3, "rectangular", 4, 10);
            ISweets milkCandy = factory.CreateMilkCandy("Korovka", 3, 2, "rectangular", 1, 7);
            ISweets frutCandy = factory.CreateFrutCandy("Abricosovye Candy", 2.4, 1.2, "elliptical", "apricot", 6);
            ISweets stickOfConfectioneryS = factory.CreateStickOfConfectionery("Snikers stickOfConfectionery", 35, 27,
                15, 15);
            ISweets stickOfConfectioneryM = factory.CreateStickOfConfectionery("Mars stickOfConfectionery", 25, 15, 20,
                13);
            ISweets wafer = factory.CreateWafer("Chernomorskie wafers", 6, 3, 2, 11);
            NewYearsGift gift =new NewYearsGift();
            gift.Add(new[] {lollipop, chocolateCandy, stickOfConfectioneryM, stickOfConfectioneryS, wafer, milkCandy,
                       frutCandy});
            //gift.Add(new List<ISweets> {lollipop, chocolateCandy, stickOfConfectioneryM, stickOfConfectioneryS, wafer, milkCandy,
            //            frutCandy});
            
           

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
           

            Console.WriteLine(gift.GetAllSweets().ListAllToString());
            Console.WriteLine("*********************Finded Candyes******************");
            Console.WriteLine(gift.FindCandies(1, 7).ListCandyToString());
            Console.WriteLine("*********************Ordered Candyes By Name*********");
            Console.WriteLine(gift.OrderCandyBy(x => x.Name).ListCandyToString());

            Console.WriteLine("*********************Finded Sweets******************");
            Console.WriteLine(gift.FindSweets(3,15).ListAllToString());
            Console.WriteLine("*********************Ordered Sweets By Name*********");
            Console.WriteLine(gift.OrderSweetsBy(x=>x.Name).ListAllToString());
            Console.WriteLine(gift.GetType().Name + " in "+package.Material+" package " + package.Color);

            Console.ReadLine();
        }
    }
}
