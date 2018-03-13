using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WhyBlog.Infrastructure;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using WhyBlog.EF;
using WhyBlog.DominService;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;

namespace WhyBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }

  

        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //Singleton是所有的service都用单一的实例，Scoped 是一个请求一个实例，Transient 每次使用都是新实例。
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WhyBlog.EF.BlogContext>(options => options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));
            services.AddDbService();
            services.AddAutoMapper();
            services.AddDominService();
            services.AddMvc().AddJsonOptions(options =>
            {
                //驼峰式命名，返回js格式 首字母小写
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            }).AddSessionStateTempDataProvider();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddAuthentication("login").AddCookie("login", options =>
            {
                options.AccessDeniedPath = "/home/contact/";
                options.LoginPath = "/home/index/";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
               // app.UseExceptionHandler("/error");
            }
            //use the UseAuthentication method to invoke the Authentication Middleware that sets the HttpContext.User property. Call the UseAuthentication method before calling AddMvcWithDefaultRoute in an MVC app or AddMvc in a Razor Pages app:
            //使用UseAuthentication 给HttpContext.User,默认赋值
           
            app.UseAuthentication();
            app.UseSession();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}
