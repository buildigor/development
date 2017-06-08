using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverFolder = ConfigurationManager.AppSettings["CSVUploadFolder"];
            string doneFolder = ConfigurationManager.AppSettings["DoneFolder"];
            string notDoneFolder = ConfigurationManager.AppSettings["NotDoneFolder"];
            CsvWorker csvWorker = new CsvWorker(serverFolder,doneFolder,notDoneFolder);
            csvWorker.RunWatch();
            Console.WriteLine(@"Press 'q' to exit");
            while (Console.Read() != 'q')
            {
            }
        }
    }
}
