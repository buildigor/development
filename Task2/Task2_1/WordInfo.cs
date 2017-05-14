using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1
{
  public  class WordInfo
    {
      public string Word { get; set; }
      public int WordCount { get; set; }
      public List<int> LineNumbers { get; set; }

      public WordInfo(string word, int firstLineNumber)
      {
          Word = word;
          WordCount = 1;
          LineNumbers = new List<int>() { firstLineNumber };
      }
    }
}
