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
        public SentenceElement(string sentenceElementValue,SentenceElementTypes sentenceElementType)
        {
            Value = sentenceElementValue;
            SentenceElementType = sentenceElementType;
        }

        public string Value { get; set; }
        public SentenceElementTypes SentenceElementType { get; private set; }
       
    }
}
