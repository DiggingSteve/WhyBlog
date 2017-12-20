using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WhyBlog.Models.Dto;
using WhyBlog.Models.Vo;

namespace WhyBlog.DominService
{
    public interface ISignInService
    {
        GitUser GetGitUser();

         Task<GitUser> OauthFromGit(GitSignInPara data);
    }
}
