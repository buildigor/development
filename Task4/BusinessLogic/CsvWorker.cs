using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BusinessLogic.DTO;
using NLog;

namespace BusinessLogic
{
    public class CsvWorker:IDisposable
    {
        private FileSystemWatcher _watcher;
        private readonly string _serverFolder;
        private readonly string _doneFolder;
        private readonly string _notDoneFolder;
        private readonly RepositoryWorker _repositoryWorker;
        private readonly Logger _logger;

        public CsvWorker(string serverFolder, string doneFolder,string notDoneFolder)
        {
            _serverFolder = serverFolder;
            _doneFolder = doneFolder;
            _notDoneFolder = notDoneFolder;
            _repositoryWorker = new RepositoryWorker();
            _logger = LogManager.GetCurrentClassLogger();
           if (!Directory.Exists(_serverFolder))
            {
                try
                {
                    Directory.CreateDirectory(_serverFolder);
                    //  _logger.Info("Directory {0} created",_serverFolder);
                    LoggerHelper.Message(string.Format("Directory {0} created", _serverFolder));
                }
                catch (Exception e)
                {

                    LoggerHelper.Error(string.Format("Directory {0} not created {1}", _serverFolder,e.Message));
                    return;
                }

            }
           _watcher = new FileSystemWatcher(_serverFolder, "*.csv");
           _watcher.Created += _watcher_Created;
        }

        private ICollection<SaleDto> ParsingFile(string path)
        {
            ICollection<SaleDto> salesCollection = new List<SaleDto>();
            var fileName = Path.GetFileName(path);
            if (fileName == null) return null;
            var fileNameSplit = fileName.Split('_','.');
            string managerName=null;
            if (Regex.IsMatch(fileNameSplit[0], "^[a-zA-Z]+$") && Regex.IsMatch(fileNameSplit[1], "^[0-9]+$"))
            {
                managerName = fileNameSplit[0];
                LoggerHelper.Message(string.Format("File name {0} format is valid", fileName));
               // Console.WriteLine("File name {0} format is valid",fileName);
            }
            else
            {
                if (Regex.IsMatch(fileNameSplit[0], "^[0-9]+$") && Regex.IsMatch(fileNameSplit[1], "^[a-zA-Z]+$"))
                {
                    managerName = fileNameSplit[1];
                    LoggerHelper.Message(string.Format("File name {0} format is valid but order is confused", fileName));
                   // Console.WriteLine("File name {0} format is valid but order is confused",fileName);
                }
                else
                {
                    LoggerHelper.Message(string.Format("File name {0} format is not correct, expected format: \"Lastname_ddmmyyyy\"", fileName));
                   // Console.WriteLine("File name {0} format is not correct, expected format: \"Lastname_ddmmyyyy\"",fileName);
                    MoveFile(path,_notDoneFolder);
                    return null;
                }
            }
            using (StreamReader sr = new StreamReader(path,Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var splitSale = sr.ReadLine().Split(',');
                    for (int i = 0; i < splitSale.Length; i++)
                    {
                        if (splitSale[i].Contains("\""))
                        {
                          splitSale[i]= splitSale[i].Replace("\"", "");
                        }
                    }
                    if (splitSale[0].Trim() == string.Empty) continue;
                    SaleDto saleDto = new SaleDto()
                    {
                        Date = DateTime.ParseExact(splitSale[0].Trim(),"ddMMyyyy",CultureInfo.CurrentCulture),
                        Manager = managerName,
                        Client = splitSale[1].Trim(),
                        Product = splitSale[2].Trim(),
                        Amount = Convert.ToDouble(splitSale[3].Trim()),
                        FileNameProcessed = fileName
                    };
                    salesCollection.Add(saleDto);
                }
            }
            return salesCollection;
        }

        private void MoveFile(string path,string destpath)
        {
            string fileName = Path.GetFileName(path);
            string destFileName = destpath + Path.GetFileNameWithoutExtension(fileName) + "_" + DateTime.Now.Hour +
                                  "-" + DateTime.Now.Minute+"-"+DateTime.Now.Millisecond + ".csv";
            if (!Directory.Exists(destpath))
            {
                Directory.CreateDirectory(destpath);
                LoggerHelper.Message(string.Format("Created ditectory {0} ", destpath));
            }
            try
            {
                if (File.Exists(path))
                {
                    File.Move(path, destFileName);
                    LoggerHelper.Message(string.Format("File {1} moved to: {0}", destpath, fileName));
                   // Console.WriteLine("File {1} moved to: {0}", destpath, fileName);
                }
            }
            catch (Exception e)
            {
                LoggerHelper.Error(string.Format("File {0} Move error: {1}",fileName, e));
               // Console.WriteLine("File Move error: {0}", e);
            }

                
        }
        void  _watcher_Created(object sender, FileSystemEventArgs e)
        {
            LoggerHelper.Message(string.Format("Created new file: {0}", e.Name));
            var task = new Task(() =>
            {
                var sales = ParsingFile(e.FullPath);
                if (sales == null) return;
                foreach (var sale in sales)
                {
                    _repositoryWorker.AddSale(sale);
                }
                LoggerHelper.Message(string.Format("Start moved file: {0}", e.Name));
                MoveFile(e.FullPath, _doneFolder);
                _repositoryWorker.AddCsvFileProcessedInfo(e.Name);
                LoggerHelper.Message(string.Format("File: {0} processed successfully", e.Name));
            });
            task.Start();
        }

        public void RunWatch()
        {
            LoggerHelper.Message(string.Format("Start watсhing folder {0}", _serverFolder));
           // Console.WriteLine("Start watсhing folder {0}",_serverFolder);
            _watcher.EnableRaisingEvents = true;
        }

        public void StopWatch()
        {
            LoggerHelper.Message("Watching Stopped");
           // Console.WriteLine("Watching Stopped");
            _watcher.EnableRaisingEvents = false;
        }

        public void Dispose()
        {
            if (_watcher == null) return;
            StopWatch();
            _watcher.Dispose();
            _watcher = null;
        }
    }
}
