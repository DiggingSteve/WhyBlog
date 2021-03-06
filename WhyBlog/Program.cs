﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace WhyBlog
{
    public class Program
    {
        // NLog: setup the logger first to catch all errors
        
        public static void Main(string[] args)
        {
            // NLog: setup the logger first to catch all errors
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
                BuildWebHost(args).Run();
            }
            catch (Exception e)
            {
                //NLog: catch setup errors
                logger.Error(e, "Stopped program because of exception");
                throw;
            }
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var a = WebHost.CreateDefaultBuilder(args);

            a.UseDefaultServiceProvider((context, config) =>
            {
                if (!context.HostingEnvironment.IsDevelopment())
                {
                    a.UseUrls(context.Configuration.GetSection("HostUrl").Value); // change your custom port 
                }
            });
            a.UseNLog();// NLog: setup NLog for Dependency injection
            a.UseStartup<Startup>();
            return a.Build();
        }
    }
}
