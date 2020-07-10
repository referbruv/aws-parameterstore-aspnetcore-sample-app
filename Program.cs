using System;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ParamStoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                    //webBuilder.UseIISIntegration();
                })
                .ConfigureAppConfiguration((builder) =>
                {
                    builder.AddSystemsManager(
                        path: "/myparams", 
                        awsOptions: new AWSOptions
                        {
                            Region = RegionEndpoint.USWest2
                        }, 
                        optional: false, 
                        reloadAfter: TimeSpan.FromMinutes(10));
                });
    }
}
