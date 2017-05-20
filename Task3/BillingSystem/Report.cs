using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
  public  class Report
  {
      private readonly IList<ReportCallInfo> _listCallInfo;

      public Report()
      {
          _listCallInfo = new List<ReportCallInfo>();
      }

      public void AddCallInfo(ReportCallInfo info)
      {
          _listCallInfo.Add(info);
      }

      public IList<ReportCallInfo> GetCallInfo()
      {
          return _listCallInfo;
      }
  }
}
