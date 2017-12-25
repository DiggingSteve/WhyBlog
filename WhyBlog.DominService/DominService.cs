using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using WhyBlog.Infrastructure.Core;

namespace WhyBlog.DominService
{
  public  class DominService
    {
        protected Context Context { get; set; }
        protected IMapper _mapper;


        public DominService(IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
             Context = new Context(httpContextAccessor.HttpContext);
            _mapper = mapper;
        }
    }
}
