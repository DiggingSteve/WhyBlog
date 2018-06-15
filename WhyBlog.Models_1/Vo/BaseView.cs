using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.Models.Vo
{
   public class BaseView
    {
        public BaseView(HttpContext context)
        {
            this.RootPath ="http://"+ context.Request.Host + context.Request.PathBase;
        }
        public string RootPath { get; set; }

        public bool IsLogin { get; set; }

        public UserView User { get; set; }
    }
}
