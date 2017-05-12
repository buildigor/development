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
      private readonly IEnumerable<ISentenceElement> _sententenceElements;

      public Sentence(string sentence) 
      {
          _sententenceElements = new List<ISentenceElement>();
          string[] splitSentence = Regex.Split(sentence, "([' ',:\\-\\.])");
          _sententenceElements = splitSentence.Where(s=>s!=" "&s!="").Select(z => new SentenceElement(z)).ToList();
      }

  

      public int GetWordsCount()
      {
          return _sententenceElements.Count(sentenceElement => sentenceElement.SentenceElementType == SentenceElementTypes.Word);
      }

      public int GetElementsCount()
      {
          return _sententenceElements.Count();
      }

      public void DeleteWords(int wordLenght)
      {
          
      }

      public void ReplaceWords(int wordLenght, string newValue)
      {
          
      }
    }
}
