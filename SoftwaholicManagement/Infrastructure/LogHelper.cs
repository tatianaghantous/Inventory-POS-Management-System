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
            TimerLog.Interval = 60000 * 1;//each  xmin
            TimerLog.Tick += async (sender, args) => await HttpRequestsClass.CheckAndProcessLogs();
            TimerLog.Start();
        }

        public static void logException(Exception ex)
        {
            ConfigureLogging();

            if (CanAccessLogFile())
            {
                Log.Error("Unhandled exception occurred. Message: {ExceptionMessage}, StackTrace: {StackTrace}", ex.Message, ex.StackTrace);

                Log.CloseAndFlush();
            }
        }

        private static bool CanAccessLogFile()
        {
            try
            {

                // Attempt to open the log file with read/write access
                using (var fileStream = new FileStream(todayLogFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                                       .ReadFrom.Configuration(AppConfig.Configuration)
            .CreateLogger();

            string logFilePath = AppConfig.Configuration["Serilog:WriteTo:1:Args:path"];
            logFilePath = Environment.ExpandEnvironmentVariables(logFilePath);

            todayLogFilePath = $"{Path.GetFileNameWithoutExtension(logFilePath)}{DateTime.Now:yyyyMMdd}.json";
        }


    }
}

