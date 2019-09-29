using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApp
{
    public class Program
    {
        public static string sConnectionString;
        public static void Main(string[] args)
        {
            //String sConnString = "Host=localhost;Port=5432;Username=GPN_test;Password=1;Database=GPN_test;";
            //WebApp.DB.DataBase db = new DB.DataBase(sConnString);
            //db.Open();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
