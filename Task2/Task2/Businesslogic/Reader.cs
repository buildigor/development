using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task2.Model;

namespace Task2.Businesslogic
{
    class Reader
    {
        private readonly string _filePath;

        public Reader(string filePath)
        {
            _filePath = filePath;
        }

        public string Read()
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
       using (StreamReader streamReader = new StreamReader(_filePath,Encoding.Default))
            {
                while (!streamReader.EndOfStream)
                {
                    stringBuilder.AppendLine(streamReader.ReadLine());
                }
            }
            var text = stringBuilder.ToString();
                return text;
            }
            catch (Exception e)
            {

                return e.ToString();
            }
     

            
        }

    }
}
