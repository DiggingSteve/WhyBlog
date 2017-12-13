using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.EF.Entity;

namespace WhyBlog.EF.Service
{
    public class UserService : BaseService<User>,IUserService
    {
        public UserService(BlogContext db) : base(db)
        {
        }
    }
}
