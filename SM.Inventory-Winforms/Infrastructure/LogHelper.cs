using Microsoft.Identity.Client;
using Microsoft.VisualBasic.Logging;
using Serilog;
using SM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log = Serilog.Log;

namespace SM.Infrastructure
{
    public class LogHelper
    {
        static string todayLogFilePath;
        public static async Task SetupTimerAndStartLogsTimer()
        {
            HttpRequestsClass.CheckAndProcessLogs();

            System.Windows.Forms.Timer TimerLog = new System.Windows.Forms.Timer();
            TimerLog.Interval = 60000 * 1;//each  1min
            TimerLog.Tick += async (sender, args) => await HttpRequestsClass.CheckAndProcessLogs();
            TimerLog.Start();
        }
        public static void logException(Exception e)
        {
            ConfigureLogging();


            Log.Error("Unhandled exception occurred. Message: {ExceptionMessage}, StackTrace: {StackTrace}", e.Message, e.StackTrace);


            Log.CloseAndFlush();
        }

        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                                       .ReadFrom.Configuration(AppConfig.Configuration)
                                       .CreateLogger();
        }


        //private static bool CanAccessLogFile()
        //{
        //    try
        //    {

        //        // Attempt to open the log file with read/write access
        //        using (var fileStream = new FileStream(todayLogFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
        //        {
        //            return true;
        //        }
        //    }
        //    catch (IOException)
        //    {
        //        return false;
        //    }
        //    catch (UnauthorizedAccessException)
        //    {
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}

    }
}

