using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1
{
   static class Result
    {
       public static void SaveToFile(string filePath,string concordance)
       {
           using (StreamWriter streamWriter = new StreamWriter(filePath))
           {
               streamWriter.Write("{0}{1}",concordance,Environment.NewLine);
           }
       }
    }
}
