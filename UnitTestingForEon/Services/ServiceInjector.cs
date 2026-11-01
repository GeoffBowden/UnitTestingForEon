using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using UnitTestingForEon.Database;
using UnitTestingForEon.Database.Mappers;
using UnitTestingForEon.ServiceLayer;

namespace UnitTestingForEon.Services
{
    public static class ServiceInjector
    {
        public static IHost InjectServices(string[] args)
        {
            //private static readonly Logger Logger =
            //  LogManager.GetCurrentClassLogger();
            /*
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);
            hostBuilder = hostBuilder.ConfigureServices((context, services) => {
                services.AddSingleton<IDatabase, DBConnectionDetails>();
                services.AddTransient<MainForm>();
            });
            */

            HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);// CreateDefaultBuilder();
            IServiceCollection services = hostBuilder.Services;
            // add the logging
            hostBuilder.Logging.ClearProviders();
            hostBuilder.Logging.AddNLog();
            // available from host IConfiguration configuration = builder.Configuration;
            // add services
            services.AddSingleton<IDatabaseConnection, DBConnection>();
            services.AddTransient<MainForm>();
            services.AddTransient<VendorMapper>();
            services = AddLoggingWrappers(services);
            IHost host = hostBuilder.Build();
            return host;
        }
        private static IServiceCollection AddLoggingWrappers(IServiceCollection services)
        {
            services.AddTransient<LoggingService<MainForm>>();
            services.AddTransient<LoggingService<VendorMapper>>();
            return services;
        }
    }
}
