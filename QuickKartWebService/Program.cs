using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using static System.Net.WebRequestMethods;

namespace QuickKartWebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //var builder = WebApplication.CreateBuilder(args);

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
//.ConfigureAppConfiguration((context, config) =>
//{
//var keyVaultEndpoint = new Uri("https://quickkartwebservicevaul5.vault.azure.net"); //new Uri(Environment.GetEnvironmentVariable("https://quickkartwebservicevaul5.vault.azure.net"));
//config.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
//})
//.ConfigureAppConfiguration((context, config) =>
//{
//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("QuickKartWebServicevaul5"));
//config.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
//})
//.ConfigureAppConfiguration((context, config) =>
//{
//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("QuickKartWebServicevaul5"));
//config.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
//})

            
.ConfigureAppConfiguration((context, config) =>
{
    var keyVaultEndpoint = new Uri($"https://quickkartwebservicevaul5.vault.azure.net/");
    config.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

