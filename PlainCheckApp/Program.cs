using Microsoft.Extensions.DependencyInjection;
using PlainCheckApp.Infrastructure;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlainCheckApp
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Infinite)
                .CreateLogger();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ServiceProvider = DependencyBuilder.ConfigureServices();
            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }
    }
}
