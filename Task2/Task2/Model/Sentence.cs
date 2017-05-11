using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Contracts;
using Task2.Enums;

namespace Task2.Model
{
  public  class Sentence:ISentence
    {
      private readonly List<ISentenceElement> _sententenceElements;

      public Sentence()
      {
          _sententenceElements = new List<ISentenceElement>();
      }

      public void Add(ISentenceElement element)
      {
          _sententenceElements.Add(element);
      }

      public int GetWordsCount()
      {
          return _sententenceElements.Count(sentenceElement => sentenceElement.SentenceElementType == SentenceElementTypes.Word);
      }

      public int GetElementsCount()
      {
          return _sententenceElements.Count;
      }

      public void DeleteWords(int wordLenght)
      {
          
      }

      public void ReplaceWords(int wordLenght, string newValue)
      {
          
      }
    }
}
