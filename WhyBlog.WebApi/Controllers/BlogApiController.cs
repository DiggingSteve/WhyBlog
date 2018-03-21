using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.DominService;
using WhyBlog.Infrastructure.Core;
using WhyBlog.Models.Po;
using WhyBlog.Models.Dto;
using WhyBlog.Models.Vo;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WhyBlog.WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    public  class BlogApiController:BaseController
    {
        private IHostingEnvironment _host = null;
        private IBlogService _blogService;

        public BlogApiController(IBlogService blogService, IHttpContextAccessor httpContextAccessor,IHostingEnvironment host) :base(httpContextAccessor)
        {
            _blogService = blogService;
            _host = host;
        }

        [HttpPost]
        public bool NewBlog(BlogInputPara input)
        {
            
            return _blogService.InsertBlog(input);
        }

        [HttpPost]
        public WangEditorResult UploadImg()
        {
            var uploadfile = Request.Form.Files;
            long size = 0;
            var result = new WangEditorResult() { Errno = 0 };
            var relativePath= "/upload/" + DateTime.Now.ToString("yyyyMMdd") + "/" + Context.BlogUser.Id.ToString();
            var directoryPath = _host.WebRootPath + relativePath;
            if (!Directory.Exists(directoryPath)){ Directory.CreateDirectory(directoryPath); }
            foreach (var file in uploadfile)
            {
                //var fileName = file.FileName;
                var fileName = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
            
                result.Data.Add(Request.Scheme+"://"+Request.Host + relativePath+$@"/{fileName}");
                fileName =directoryPath+ $@"/{fileName}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            
            }
           
            
            return result;
        }


        [HttpGet]
        public BlogPageView GetBlogs(int pageIndex)
        {

            return _blogService.GetBlogs(pageIndex);
        }

        [HttpGet]
        public BlogListView GetBlog(int id)
        {

            return _blogService.GetBlog(id);
        }
    }
}
