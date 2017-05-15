using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2_1
{
   public class Concordance
    {
       private readonly Dictionary<string,WordInfo> _concordanceDictionary = new Dictionary<string, WordInfo>();

       public string[] SplitLine(string line)
       {
           return Regex.Split(line, "\\W");
       }

       public void AddWordsToDictionary(string[] lineStrings)
       {
           int i=0;
           int n=5;
           foreach (var line in lineStrings)
           {
               foreach (string word in SplitLine(line.ToLower()))
               {
                   if (!_concordanceDictionary.ContainsKey(word))
                   {
                       _concordanceDictionary.Add(word, new WordInfo(word, i/n + 1));
                       if (_concordanceDictionary.ContainsKey(""))
                       {
                           _concordanceDictionary.Remove("");
                       }
                   }
                   else
                   {
                       _concordanceDictionary[word].WordCount++;
                       if (!_concordanceDictionary[word].LineNumbers.Contains(i/n + 1))
                       {
                           _concordanceDictionary[word].LineNumbers.Add(i/n + 1);
                       }
                   }
               }
               i++;
           }
       }

       public string ShowConcordance()
       {
           string concordance = null;
           List<WordInfo> sortedWords = _concordanceDictionary.Values.OrderBy(x => x.Word).ToList();
           string prevUpperLetter = "";
           foreach (var grupped in sortedWords)
           {
               concordance += Environment.NewLine;
               string nextUpperLetter = grupped.Word.Substring(0, 1).ToUpper();
               if (nextUpperLetter != prevUpperLetter)
               {
                   concordance += Environment.NewLine;
                   concordance += "[" + nextUpperLetter + "]" + Environment.NewLine;
               }
               prevUpperLetter = grupped.Word.Substring(0, 1).ToUpper();
               concordance += grupped.Word + " " + grupped.WordCount + ": ";
               concordance = grupped.LineNumbers.Aggregate(concordance, (current, number) => current + (" " + number));
           }
           return concordance;
       }
    }
}
