using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.Models.Vo
{
    /// <summary>
    /// 首页展示blog model 包含分页信息 和 BlogListView
    /// </summary>
   public class BlogPageView
    {
      public  IEnumerable<BlogListView> BlogList { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }

        public int PageCount { get; set; }
    }
}
