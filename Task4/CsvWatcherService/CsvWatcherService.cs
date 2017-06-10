using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace CsvWatcherService
{
    public partial class CsvWatcherService : ServiceBase
    {
        private CsvWorker _csvWorker;
        public CsvWatcherService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string serverFolder = ConfigurationManager.AppSettings["CSVUploadFolder"];
            string doneFolder = ConfigurationManager.AppSettings["DoneFolder"];
            string notDoneFolder = ConfigurationManager.AppSettings["NotDoneFolder"];
            _csvWorker = new CsvWorker(serverFolder, doneFolder, notDoneFolder);
            _csvWorker.RunWatch();
            
        }

        protected override void OnStop()
        {
            try
            {
                _csvWorker.StopWatch();
            }
            finally
            {
                _csvWorker.Dispose();
            }
        }
    }
}
