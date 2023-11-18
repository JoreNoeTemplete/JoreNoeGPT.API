using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace JoreNoeBackTemplete.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
             .UseServiceProviderFactory(new AutofacServiceProviderFactory())
             .ConfigureAppConfiguration((appConfiguration, builder) =>
             {
                 builder
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("Configs/Redis.json", optional: false, reloadOnChange: true)
               .AddJsonFile("Configs/Exceptionless.json", optional: false, reloadOnChange: true)
               .AddJsonFile("Configs/WeChatOpenConfig.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables().Build();
             })
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();
                 webBuilder.UseUrls("http://*:5000");
             });
    }
}
