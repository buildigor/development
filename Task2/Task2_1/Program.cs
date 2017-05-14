using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader("text.txt");
            string[] testList = reader.Read();
            Concordance concordance = new Concordance();
            string[] testList1 = concordance.SplitLine(testList[1]);
            Console.ReadLine();
        }
    }
}
