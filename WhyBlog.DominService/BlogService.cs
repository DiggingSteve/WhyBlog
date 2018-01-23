using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.EF.Dao;
using WhyBlog.Models.Do;
using WhyBlog.Models.Dto;

namespace WhyBlog.DominService
{
    public class BlogService : DominService, IBlogService
    {
        protected IBlogDao _blogDao;

        public BlogService(IBlogDao blogDao, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            _blogDao = blogDao;
        }

        public IEnumerable<Blog> GetBlogs()
        {
         return   _blogDao.Get(p => p.Uid == _context.BlogUser.Id);
        }

        public bool InsertBlog(BlogInputPara input)
        {
            input.Uid = _context.BlogUser.Id;
            if (string.IsNullOrWhiteSpace(input.Title)) { input.Title = "未命名标题"; }
            Blog blog = _mapper.Map<Blog>(input);
            return _blogDao.Add(blog) > 0 ? true : false;
        }
    }
}
