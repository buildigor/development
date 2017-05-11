using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Businesslogic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Reader textReader = new Reader("text.txt");
            textReader.Read();
        }
    }
}
