using AutoMapper;
using WhyBlog.Models.Do;
using WhyBlog.Models.Dto;
using WhyBlog.Models.Vo;

namespace Models.Map.SourceFile
{
    public class UserConfig : Profile
    {
        public UserConfig()
        {
            CreateMap<GitUser, User>()
                .ForMember(des => des.UserName, opt => opt.MapFrom(p => p.Name))
                .AfterMap((source, des) =>
                {
                    des.UserSource = "Git";
                });

            CreateMap<GitUser, UserView>()
                  .ForMember(des => des.NickName, opt => opt.MapFrom(p => p.Name));

        }
    }
}
