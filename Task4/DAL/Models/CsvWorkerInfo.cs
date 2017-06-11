using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
  public  class CsvWorkerInfo
    {
      public int Id { get; set; }
      public string FileNameProcessed { get; set; }
      public DateTime DateProcessed { get; set; }
    }
}
