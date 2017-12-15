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
using WhyBlog.EF.Service;
using WhyBlog.EF.Entity;
using Newtonsoft.Json.Serialization;

namespace WhyBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //Singleton是所有的service都用单一的实例，Scoped 是一个请求一个实例，Transient 每次使用都是新实例。
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WhyBlog.EF.BlogContext>(options => options.UseMySql(AppConfig.MySqlConnection));
            services.AddDbService();
            services.AddMvc().AddJsonOptions(options =>
            {
                //驼峰式命名，返回js格式 首字母小写
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            }); ;
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCookiePolicy();
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
