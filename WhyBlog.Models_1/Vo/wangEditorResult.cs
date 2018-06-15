using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.Models.Vo
{
   public class WangEditorResult
    {
        public WangEditorResult()
        {
            this.Data = new List<string>();
        }
        public int Errno { get; set; }

        public List<string> Data { get; set; }
    }
}
