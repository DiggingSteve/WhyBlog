using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.DominService;
using WhyBlog.Infrastructure.Core;
using WhyBlog.Models.Do;
using WhyBlog.Models.Dto;
using WhyBlog.Models.Vo;

namespace WhyBlog.WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    public  class BlogApiController:BaseController
    {
        private IBlogService _blogService;

        public BlogApiController(IBlogService blogService, IHttpContextAccessor httpContextAccessor) :base(httpContextAccessor)
        {
            _blogService = blogService;
        }

        [HttpPost]
        public bool NewBlog(BlogInputPara input)
        {
            
            return _blogService.InsertBlog(input);
        }


        [HttpGet]
        public IEnumerable<BlogListView> GetBlogs()
        {

            return _blogService.GetBlogs();
        }
    }
}
