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
                .ForMember(des => des.Id, opt => opt.Ignore())
                .ForMember(des => des.UserName, opt => opt.MapFrom(p => p.Login))
                .ForMember(des => des.Sid, opt => opt.MapFrom(p => p.Id))
                .AfterMap((source, des) =>
                {
                    des.UserSource = "Git";
                });

            CreateMap<GitUser, UserView>()
                  .ForMember(des => des.NickName, opt => opt.MapFrom(p => p.Name));

            CreateMap<User, UserView>()
                .ForMember(des => des.NickName, opt => opt.MapFrom(p => p.UserName));

        }
    }
}
