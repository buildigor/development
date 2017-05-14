using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2.Contracts;

namespace Task2.Model
{
    public class TrimmedText : IText
    {
        public IEnumerable<ISentence> Sentences { get; private set; }

        public TrimmedText(string text)
        {
            Sentences = new List<ISentence>();
            text = text.Trim().Replace(Environment.NewLine, " ");
            while (text.IndexOf("  ", StringComparison.Ordinal) != -1)
            {
                text = text.Replace("  ", " ");
            }
            string[] splittext = Regex.Split(text, "(?<=[\\.!?])");
            Sentences = splittext.Where(s => s != "" & s != ".").Select(z => new Sentence(z)).ToList();
        }


        public int GetCountSentences()
        {
            return Sentences.Count();
        }


        public override string ToString()
        {
            return string.Join(Environment.NewLine, Sentences);
        }

        public List<string> GetSentences()
        {
            return Sentences.Select(x => x.Value).ToList();
        }
        public ISentence GetSentenceByIndex(int index)
        {
            return Sentences.ToList()[index];
        }
    }
}
