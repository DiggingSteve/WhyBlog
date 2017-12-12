using System;
using Microsoft.Extensions.Configuration;

namespace WhyBlog.Infrastructure
{
    public class AppConfig
    {
        public static string MySqlConnection { get;  } = ConfigurationManager.Configuration.GetConnectionString("MySqlConnection");
    }
}
