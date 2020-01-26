using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SitaAssignment.Configuration;
using SitaAssignment.Data;
using SitaAssignment.Model;
using SitaAssignment.Services;
using SitaAssignment.SortingCriteria;


namespace SitaAssignment
{
    public class Program
    {
        public static IMailHandlersConfiguration HandlersConfig { get; set; }
        public static IConnectionStrings ConnectionStrings { get; set; }
        private static ServiceProvider _serviceProvider; //IoC
        
        public static void Main(string[] args)
        {
            LoadConfiguration();
            ConfigureDi();

            var parcelService = _serviceProvider.GetService<IParcelService>();
            var groupedParcels = parcelService.GetGroupedMail();
            var totalParcels = parcelService.GetAllMail().Count();

            WriteResultsToConsole(totalParcels, groupedParcels);
        }

        private static void WriteResultsToConsole(int totalParcels, IEnumerable<GroupedParcels> groupedParcels)
        {
            Console.WriteLine();
            Console.WriteLine($@"{totalParcels} parcels found in the '{ConnectionStrings.XmlFile}]' file.");
            Console.WriteLine("--------------------------------------------------------------------------");

            foreach (var parcelGroup in groupedParcels)
            {
                var count = 0;
                Console.WriteLine();
                Console.WriteLine($@"{parcelGroup.Handler} will handle a total of {parcelGroup.Parcels.Count()} parcels");

                foreach (var parcel in parcelGroup.Parcels)
                {
                    Console.WriteLine($@"    {++count}. From [{parcel.Company.Name}] To [{parcel.Receipient.Name}]");
                }
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
        }

        private static void ConfigureDi()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton(ConnectionStrings)
                .AddSingleton(HandlersConfig)
                .AddScoped<ICriteria, StandardCriteria>()
                .AddScoped<IXmlRepository, XmlRepository>()
                .AddScoped<IParcelService, ParcelService>()
                .BuildServiceProvider();
        }

        private static void LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();

            // var config = builder.Build();

            HandlersConfig = new MailHandlersConfiguration  { MailHandlers = config.GetSection("MailHandlersConfiguration").Get<List<MailHandler>>() };
            ConnectionStrings = config.GetSection("ConnectionStrings").Get<ConnectionStrings>();
        }
    }
}
