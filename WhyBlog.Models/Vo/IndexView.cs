using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.Models.Vo
{
   public class IndexView:BaseView
    {
        public IndexView(HttpContext cotext) :base(cotext){ }
    }
}
