using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using WhyBlog.Models.Po;
using WhyBlog.Models.Dto;
using WhyBlog.Models.Vo;
using System.Linq;
using WhyBlog.EF;

namespace WhyBlog.DominService
{
    public class BlogService : DominService, IBlogService
    {
        
        private readonly BlogContext _db;

        public BlogService(BlogContext db, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
           
            this._db = db;
        }

        public BlogListView GetBlog(int id)
        {
            
            Blog blog= _db.Blogs.Where(p => p.Id == id).Include(p=>p.User).FirstOrDefault();
            BlogListView blogView = _mapper.Map<BlogListView>(blog);
            return blogView;
        }

        public BlogPageView GetBlogs(int pageIndex)
        {
            int pageSize = 10;
            BlogPageView blogResult = new BlogPageView();
            int count = _db.Blogs.Count();
            blogResult.BlogList= _db.Blogs.OrderByDescending(p => p.CreateTime).
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
            blogResult.PageCount = count / pageSize+1;
            if (blogResult.PageCount == 0) blogResult.PageCount = 1;
            blogResult.PageIndex = pageIndex;
            return blogResult;

        }

        public bool InsertBlog(BlogInputPara input)
        {
            input.Uid = _context.BlogUser.Id;
            if (string.IsNullOrWhiteSpace(input.Title)) { input.Title = "未命名标题"; }
            Blog blog = _mapper.Map<Blog>(input);
            _db.Blogs.Add(blog);
            return _db.SaveChanges() > 0;
        }
    }
}
