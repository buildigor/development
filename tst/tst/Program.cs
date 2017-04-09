using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tst
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiArray();
            
        }

        private static void MultiArray()
        {
            byte[,]image = new byte[5,11];
            for (int i = 0; i < 5; i++)
            
                for (int j = 0; j <= 10; j++)
                
                    image[i, j] = (byte) (i*j);
                
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j <= 10; j++)
                
                    Console.Write(image[i,j]+"\t");
                Console.WriteLine();
                
            }
Console.ReadLine();
        }
        private static void FileWork()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (!File.Exists(@"d:\test1\" + i + ".txt"))
                {
                    File.Create(@"d:\test1\" + i + ".txt");
                }
            }
            Thread.Sleep(2000);
            for (int i = 0; i < 1000; i++)
            {
                if (File.Exists(@"d:\test1\" + i + ".txt"))
                {
                    File.Delete(@"d:\test1\" + i + ".txt");
                }
            }
        }
    }
}
