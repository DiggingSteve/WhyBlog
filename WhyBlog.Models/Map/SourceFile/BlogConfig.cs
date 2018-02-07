using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.Models.Po;
using WhyBlog.Models.Dto;
using WhyBlog.Models.Vo;

namespace WhyBlog.Models.Map.SourceFile
{
   public class BlogConfig:Profile
    {
        public BlogConfig()
        {
            CreateMap<BlogInputPara, Blog>();

            CreateMap<Blog, BlogListView>()
                .ForMember(des => des.Uid, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(des => des.NickName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(des => des.UserPic, opt => opt.MapFrom(src => src.User.Avatar_url));
                



        }
    }
}
