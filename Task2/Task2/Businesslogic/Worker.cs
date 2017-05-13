using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Contracts;
using Task2.Enums;
using Task2.Model;

namespace Task2.Businesslogic
{
  public  class Worker
  {
      private readonly TrimmedText _trimmedText;
      
      public Worker(TrimmedText trimmedText1)
      {
          _trimmedText = trimmedText1;
          
      }

      public List<string> SortSentencesInAscendingOrderOfTheNumberOfWords()
      {
          return _trimmedText.Sentences.OrderBy(x => x.GetWordsCount()).Select(s => s.Value).ToList();
      }

      public List<string> GetQuestionSentences()
      {
          
          return _trimmedText.Sentences.Where(x => x.Value.Contains('?')).Select(s=>s.Value).ToList();
      }

      public List<string> FindWordsByLenght(int wordLenght)
      {
          List<string> words = new List<string>();
          foreach (ISentence currentsentence in _trimmedText.Sentences.Where(x => x.Value.Contains('?')))
          {
              for (int i = 0; i < currentsentence.GetWordsCount(); i++)
              {
                  var currentElement = currentsentence.GetElementByIndex(i);
                  if (currentElement.SentenceElementType==SentenceElementTypes.Word & currentElement.Value.Length==wordLenght)
                  {
                      words.Add(currentElement.Value);
                  }
              }
          }
          return words;

      }
      public void DeleteWords(int wordLenght)
      {

      }

      public void ReplaceWords(int wordLenght, string newValue)
      {

      }
  }
}
