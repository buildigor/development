using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task2.Model;

namespace Task2.Businesslogic
{
    class Reader
    {
        private readonly string _filePath;
        private readonly string _bufLine;
        public Reader(string filePath)
        {
            _filePath = filePath;
            _bufLine = string.Empty;
        }

        public string Read()
        {
            string s = null;
            StringBuilder stringBuilder = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(_filePath))
            {
                while (!streamReader.EndOfStream)
                {
                 stringBuilder.AppendLine(streamReader.ReadLine());
                }
            }
            s = stringBuilder.ToString();
            while (s.IndexOf("  ", StringComparison.Ordinal) != -1)
            {
                s = s.Replace("  ", " ");
            }
           s= s.TrimStart().TrimEnd();
            return s;
        }

       
    }
}
