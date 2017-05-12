using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Contracts
{
   public interface ISentence
   {
       
       int GetWordsCount();
       int GetElementsCount();
       void DeleteWords(int wordLenght);
       void ReplaceWords(int wordLenght, string newValue);
   }
}
