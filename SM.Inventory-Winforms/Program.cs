using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Logging;
using Microsoft.VisualBasic.Logging;
using System.Data.SqlClient;
using System.Text;
using Velopack;
using Velopack.Windows;
using SM.Common_Functions;
using SM.DataLayer.Models;
using SM.Infrastructure;
using Serilog;
using Log = Serilog.Log;

namespace SM
{
    public static class ApplicationCache
    {
        public static List<Product>? CachedProducts { get; set; }
        public static List<Supplier>? CachedSuppliers{ get; set; }
        public static List<Category>? CachedCategories { get; set; }
        public static List<Inventory>? CachedInventories { get; set; }
        public static List<Customer>? CachedCustomers { get; set; }
        public static List<OrderSummary>? CachedAllOrders { get; set; }
        public static Image? deleteImage { get; set; } = null;
        public static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SoftwaholicApp", "ClothingStore.db");
        public static string DirectoryFolder => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SoftwaholicApp");

    }

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            VelopackApp.Build().WithAfterInstallFastCallback((v) => new Shortcuts().CreateShortcutForThisExe(ShortcutLocation.Desktop)).Run();
            Log.Logger = new LoggerConfiguration()
                             .ReadFrom.Configuration(AppConfig.Configuration)
                             .WriteTo.Seq("http://194.60.201.106:39081/")
                             .CreateLogger();
            Application.ThreadException += new ThreadExceptionEventHandler(GlobalExceptionHandler);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);
            EnsureDirectoriesExist();
            ClothingStoreContext context = new ClothingStoreContext();
            using (var _context = new ClothingStoreContext())
            {
                DatabaseInitializer.Initialize(_context);
            }
            ApplicationConfiguration.Initialize();


            CachingItems(context);

            BackupHelper.SetupBackupTimerndStartItIfNecessary();
            Infrastructure.LogHelper.SetupTimerAndStartLogsTimer();
            
            Application.Run(new loginForm(context));

        }
        public static void UpdateMyApp()
        {
                var mgr = new UpdateManager(AppConfig.GetURL() + AppConfig.GetBucketName());
                var newVersion = mgr.CheckForUpdates();
                if (newVersion == null)
                    return;

                // download new version 
                mgr.DownloadUpdates(newVersion);
                mgr.ApplyUpdatesAndRestart(newVersion);
                MessageBox.Show("New Update Downloaded");
        }
        public static void EnsureDirectoriesExist()
        {
            // Ensure the Database directory exists
            string dbDirectory = Path.GetDirectoryName(ApplicationCache.DatabasePath);
            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }
        }
        private static void GlobalExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            Log.Error(e.Exception, " \r\n\n An unhandled exception was caught by the global thread exception handler", "\r\n\n");
            MessageBox.Show("An application error occurred. Please contact the administrator with the following information:\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                Infrastructure.LogHelper.logException(ex);
            }
            else
            {
                Log.Error("\r\n\n An unhandled exception of unknown type was caught by the global unhandled exception handler");
            }

            MessageBox.Show("An application error occurred. Please contact the administrator with the following information:\n" + (e.ExceptionObject as Exception)?.Message ?? "Unknown error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private static void CachingItems(ClothingStoreContext context)
        {
            ApplicationCache.CachedProducts = context.Products.ToList();
            ApplicationCache.CachedSuppliers = context.Suppliers.ToList();
            ApplicationCache.CachedCategories = context.Categories.ToList();
            ApplicationCache.CachedInventories = context.Inventories.ToList();
            //ApplicationCache.CachedAllOrders = context.OrderSummaries.Include(os => os.OrderItems)
            //                                                            .Include(os => os.Buyer)
            //                                                            .Include(os => os.Seller)
            //                                                            .ToList();
         //   ApplicationCache.CachedCustomers = context.Customers.ToList();
            ApplicationCache.deleteImage = InitializeDeleteImage();
        }

        static Image InitializeDeleteImage()
        {
            Image deleteImage;

                deleteImage = ImageFunctions.ResizeImage(Image.FromFile("Assets\\bin.png"), 30, 30);
 
            return deleteImage;
        }

    }
}