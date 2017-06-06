using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CsvWorker:IDisposable
    {
        private FileSystemWatcher _watcher;
        private readonly string _serverFolder;
        private readonly string _doneFolder;

        public CsvWorker(string serverFolder, string doneFolder)
        {
            _serverFolder = serverFolder;
            _doneFolder = doneFolder;
            _watcher = new FileSystemWatcher(_serverFolder,"*.csv");
            _watcher.Created += _watcher_Created;
            if (!Directory.Exists(_doneFolder))
            {
                Directory.CreateDirectory(_doneFolder);
            }
        }

        void  _watcher_Created(object sender, FileSystemEventArgs e)
        {
            string s= string.Format("Created new file: {0}", e.Name);
            Console.WriteLine(s);
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
