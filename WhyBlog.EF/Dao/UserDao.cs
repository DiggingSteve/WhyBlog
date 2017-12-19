using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.Models.Do;

namespace WhyBlog.EF.Dao
{
    public class UserDao : BaseDao<User>,IUserDao
    {
        public UserDao(BlogContext db) : base(db)
        {
        }
    }
}
