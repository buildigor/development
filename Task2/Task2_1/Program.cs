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
            Concordance concordance = new Concordance();
            concordance.AddWordsToDictionary(reader.Read());
            concordance.ShowConcordance();
            Console.ReadLine();
        }
    }
}
