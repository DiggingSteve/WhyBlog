using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhyBlog.EF.Dao;

namespace WhyBlog.EF
{
    public static class ServiceExtension
    {
        /// <summary>
        /// 此处注册所有db的服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbService(this  IServiceCollection services)
        {
            
          return  services.AddScoped<IUserDao,UserDao>();
        }
    }
}
