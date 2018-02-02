using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.Models.Vo
{
    public class BlogView : BaseView
    {

        public BlogView(HttpContext cotext) : base(cotext)
        {
            this.Blog = new BlogListView();
        }
        public BlogListView Blog { get; set; }
    }
}
