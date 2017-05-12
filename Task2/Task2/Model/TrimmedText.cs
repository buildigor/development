using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2.Contracts;

namespace Task2.Model
{
  public  class TrimmedText:IText
    {
      private readonly IEnumerable<ISentence> _sentences;

      public TrimmedText(string text)
      {
          _sentences = new List<ISentence>();
          text = text.Trim().Replace(Environment.NewLine, " ");
          while (text.IndexOf("  ", StringComparison.Ordinal) != -1)
          {
              text = text.Replace("  ", " ");
          }
          string[] splittext = Regex.Split(text, "(?<=[\\.!?])");

          _sentences = splittext.Where(s => s != "" & s != ".").Select(z => new Sentence(z)).ToList();
      }


      public int GetCountSentences()
      {
          return _sentences.Count();
      }
    }
}
