using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BusinessLogic
{
  public static class LoggerHelper
  {
      public static readonly Logger Current;
      static LoggerHelper()
      {
          Current = LogManager.GetCurrentClassLogger();
      }
      public static void Message(string message)
      {
          if (Current != null)
              Current.Info("-------- {0}", message);
          Console.WriteLine(@"Message: {0}", message);
      }

      public static void Warning(string message)
      {
          if (Current != null)
              Current.Warn("WARNING: {0}", message);
          Console.WriteLine(@"Warning: {0}", message);
      }

      public static void Error(string message)
      {
          if (Current != null)
              Current.Error("ERROR: {0}", message);
          Console.WriteLine(@"Error: {0}", message);
      }
  }
}
