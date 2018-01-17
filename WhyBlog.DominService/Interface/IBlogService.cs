using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.Models.Do;
using WhyBlog.Models.Dto;

namespace WhyBlog.DominService
{
  public  interface IBlogService
    {
        bool InsertBlog(BlogInputPara input);

        IEnumerable<Blog> GetBlogs();
    }
}
