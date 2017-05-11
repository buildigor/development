using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2.Businesslogic;
using Task2.Model;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader textReader = new Reader("text.txt");
            List<string> Sentences = new List<string>();
            Sentences = textReader.Read();


        }
    }
}
