using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2_1
{
   public class Concordance
    {
       public Dictionary<string,WordInfo> ConcordanceDictionary = new Dictionary<string, WordInfo>();

       public string[] SplitLine(string line)
       {
           return Regex.Split(line, "\\W");
       }
    }
}
