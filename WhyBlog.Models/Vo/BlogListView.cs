using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.Models.Vo
{
   public class BlogListView
    {

        public int Uid { get; set; }
     
        public string NickName { get; set; }
        public string UserPic { get; set; }

        public string CreateTime { get; set; }

      
        public string Summary { get; set; }
        public string PicSummary { get; set; }


        public string Title { get; set; }
    }
}
