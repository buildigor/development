using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTO;

namespace BusinessLogic
{
    public class CsvWorker:IDisposable
    {
        private FileSystemWatcher _watcher;
        private readonly string _serverFolder;
        private readonly string _doneFolder;
        private RepositoryWorker _repositoryWorker;

        public CsvWorker(string serverFolder, string doneFolder)
        {
            _serverFolder = serverFolder;
            _doneFolder = doneFolder;
            _repositoryWorker = new RepositoryWorker();
            _watcher = new FileSystemWatcher(_serverFolder,"*.csv");
            _watcher.Created += _watcher_Created;
            if (!Directory.Exists(_doneFolder))
            {
                Directory.CreateDirectory(_doneFolder);
            }
        }

        private ICollection<SaleDto> ParsingFile(string path)
        {
            ICollection<SaleDto> salesCollection = new List<SaleDto>();
            var fileName = Path.GetFileName(path);
            if (fileName == null) return null;
            var managerName = fileName.Split('_').First();
            using (StreamReader sr = new StreamReader(path,Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var splitSale = sr.ReadLine().Split(',');
                    if (splitSale[0].Trim() == string.Empty) continue;
                    SaleDto saleDto = new SaleDto()
                    {
                        Date = DateTime.ParseExact(splitSale[0].Trim(),"ddMMyyyy",CultureInfo.CurrentCulture),
                        Manager = managerName,
                        Client = splitSale[1].Trim(),
                        Product = splitSale[2].Trim(),
                        Amount = Convert.ToDouble(splitSale[3].Trim()),
                    };
                    salesCollection.Add(saleDto);
                }
            }
            return salesCollection;
        }

        void  _watcher_Created(object sender, FileSystemEventArgs e)
        {
            string s= string.Format("Created new file: {0}", e.Name);
            Console.WriteLine(s);
            var sales = ParsingFile(e.FullPath);
            foreach (var sale in sales)
            {
                _repositoryWorker.AddSale(sale);
            }
        }

        public void RunWatch()
        {
            Console.WriteLine("Start watсhing folder {0}",_serverFolder);
            _watcher.EnableRaisingEvents = true;
        }

        public void StopWatch()
        {
            Console.WriteLine("Watching Stopped");
            _watcher.EnableRaisingEvents = false;
        }

        public void Dispose()
        {
            if (_watcher!=null)
            {
                StopWatch();
                _watcher.Dispose();
                _watcher = null;
            }
        }
    }
}
