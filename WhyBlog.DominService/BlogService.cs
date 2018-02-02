using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.EF.Dao;
using WhyBlog.Models.Do;
using WhyBlog.Models.Dto;
using WhyBlog.Models.Vo;
using System.Linq;

namespace WhyBlog.DominService
{
    public class BlogService : DominService, IBlogService
    {
        protected IBlogDao _blogDao;

        public BlogService(IBlogDao blogDao, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            _blogDao = blogDao;
        }

        public BlogListView GetBlog(int id)
        {
            DbSet<Blog> query= _blogDao.Get();
            Blog blog= query.Where(p => p.Id == id).Include(p=>p.User).FirstOrDefault();
            BlogListView blogView = _mapper.Map<BlogListView>(blog);
            return blogView;
        }

        public BlogPageView GetBlogs(int pageIndex)
        {
            int pageSize = 5;
            BlogPageView blogResult = new BlogPageView();
            DbSet<Blog> a = _blogDao.Get();
            blogResult.BlogList= a.OrderByDescending(p => p.CreateTime).
                Select(p => new BlogListView
                {
                    NickName = p.User.UserName,
                    CreateTime = p.CreateTime.ToString("yyyy-MM-dd HH:mm"),
                    Summary = p.Summary,
                    Title = p.Title,
                    Uid = p.Uid,
                    PicSummary = p.PicSummary,
                    UserPic = p.User.Avatar_url,
                    Id = p.Id
                }).Skip((pageIndex-1)* pageSize).Take(pageSize);
            blogResult.PageCount = a.Count()/ pageSize;
            blogResult.PageIndex = pageIndex;
            return blogResult;

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
