using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.Models.Do;
using WhyBlog.Models.Dto;

namespace WhyBlog.Models.Map.SourceFile
{
   public class BlogConfig:Profile
    {
        public BlogConfig()
        {
            CreateMap<BlogInputPara, Blog>();

         

        
        }
    }
}
