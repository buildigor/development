using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Enums;

namespace Task2.Contracts
{
   public interface ISentenceElement
    {
        string Value { get; set; }
        SentenceElementTypes SentenceElementType { get; }
    }
}
