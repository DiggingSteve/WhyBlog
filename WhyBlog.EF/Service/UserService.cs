using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.Models.Do;

namespace WhyBlog.EF.Service
{
    public class UserService : BaseService<User>,IUserService
    {
        public UserService(BlogContext db) : base(db)
        {
        }
    }
}
