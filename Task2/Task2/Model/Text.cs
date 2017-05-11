using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Contracts;

namespace Task2.Model
{
  public  class Text
    {
      private readonly List<ISentence> _sentences;

      public Text()
      {
          _sentences = new List<ISentence>();
      }
      public IEnumerable<ISentence> SortSentences()
      {
          return _sentences.OrderBy(x => x.GetWordsCount());
      }
      public override string ToString()
      {
          return string.Join(Environment.NewLine, _sentences);
      }
      public List<ISentence> GetQuestionSentences()
      {
          List<ISentence> questionSentences = new List<ISentence>();
       
          return questionSentences;

      }
    }
}
