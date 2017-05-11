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

        public List<string> Read()
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(_filePath))
            {
                while (!streamReader.EndOfStream)
                {
                 stringBuilder.AppendLine(streamReader.ReadLine());
                }
            }
            var text = stringBuilder.ToString();
            text = text.Trim().Replace(Environment.NewLine, " ");
            while (text.IndexOf("  ", StringComparison.Ordinal) != -1)
            {
                text = text.Replace("  ", " ");
            }
          return  SplitText(text);
        }

        private List<string> SplitText(string text)
        {
            string[] splittext = Regex.Split(text, "(?<=[\\.!?])");
            List<string> sentenceList = splittext.Where(s => s != "" & s != ".").ToList();
            return sentenceList;
        }
    }
}
