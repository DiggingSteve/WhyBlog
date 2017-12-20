using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.DominService
{
   public static class ServiceExtension
    {
        /// <summary>
        /// 此处注册所有db的服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDominService(this IServiceCollection services)
        {

            return services.AddScoped<ISignInService, SignInService>();
        }
    }
}
