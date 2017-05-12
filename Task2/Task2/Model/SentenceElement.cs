using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Contracts;
using Task2.Enums;

namespace Task2.Model
{
  public  class SentenceElement:ISentenceElement
    {
      private readonly string[] _marks = new[] { ",", " - ", ":" ,"\"",".","!","?","?!"};
      public SentenceElement(string sentenceElementValue)
      {
          Value = sentenceElementValue;
      }

      public string Value { get; set; }
      public SentenceElementTypes SentenceElementType { get { return _marks.Contains(Value) ? SentenceElementTypes.PunctuationMark : SentenceElementTypes.Word; } }
       
    }
}
