using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1
{
  public  class Reader
    {
      private readonly string _filePath;
        public Reader(string filePath)
        {
            _filePath = filePath;
        }

      public string[] Read()
      {
          string[] lines = new string[] {};
          try
          {
              lines = File.ReadAllLines(_filePath);

          }
          catch (Exception e)
          {

              Console.WriteLine(e.Message);
          }
          return lines;
      }
    }
}
