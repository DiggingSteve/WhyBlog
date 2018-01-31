using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.Models.Dto
{
 public   class BlogInputPara
    {
        public string Title { get; set; }

        public string Html { get; set; }

        public int Uid { get; set; }

        public string Summary { get; set; }

        public string PicSummary { get; set; }
    }
}
