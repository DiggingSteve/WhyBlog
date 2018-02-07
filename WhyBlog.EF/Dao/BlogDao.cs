using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.Models.Po;

namespace WhyBlog.EF.Dao
{
    public class BlogDao : BaseDao<Blog>, IBlogDao
    {
        public BlogDao(BlogContext db) : base(db)
        {
        }

    }
}
