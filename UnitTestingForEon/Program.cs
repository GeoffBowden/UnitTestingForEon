using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UnitTestingForEon.Services;

namespace UnitTestingForEon
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IHost host = ServiceInjector.InjectServices(args);
            MainForm mainForm = host.Services.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }
    }
}