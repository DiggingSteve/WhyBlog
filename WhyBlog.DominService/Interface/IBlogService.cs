using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.Models.Po;
using WhyBlog.Models.Dto;
using WhyBlog.Models.Vo;

namespace WhyBlog.DominService
{
  public  interface IBlogService
    {
        bool InsertBlog(BlogInputPara input);

       BlogPageView GetBlogs(int pageIndex);
        BlogListView GetBlog(int id);
    }
}
