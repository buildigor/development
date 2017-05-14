using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2.Contracts;
using Task2.Enums;

namespace Task2.Model
{
  public  class Sentence:ISentence
    {
      public IEnumerable<ISentenceElement> SententenceElements { get; private set; }
      public string Value { get; set; }
      public Sentence(string sentence)
      {
          Value = sentence;
          SententenceElements = new List<ISentenceElement>();
          string[] splitSentence = Regex.Split(sentence, "([' ',:\\-\\.])");
          SententenceElements = splitSentence.Where(s=>s!=" "&s!="").Select(z => new SentenceElement(z)).ToList();
          
      }


      public ISentenceElement GetElementByIndex(int index)
      {
          return SententenceElements.ToList()[index];
      }

      public int GetWordsCount()
      {
          return SententenceElements.Count(sentenceElement => sentenceElement.SentenceElementType == SentenceElementTypes.Word);
      }

      public override string ToString()
      {
          return Value;
      }

      public int GetElementsCount()
      {
          return SententenceElements.Count();
      }

     

      
    }
}
