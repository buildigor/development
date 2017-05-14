using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Contracts
{
   public interface ISentence
   {
       IEnumerable<ISentenceElement> SententenceElements { get;  }
       ISentenceElement GetElementByIndex(int index);
       int GetWordsCount();
       int GetElementsCount();
       string Value { get; set; }

   }
}
