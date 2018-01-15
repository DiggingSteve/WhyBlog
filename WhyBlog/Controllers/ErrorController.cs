using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;

namespace WhyBlog.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;
        

        public ErrorController(ILogger<ErrorController> logger)
        {
            this._logger = logger;
            
        }
       [Route("/Error")]
        public IActionResult Index()
        {
            var ex = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (ex != null)
            {
                _logger.LogError(ex.Error, ex.Error.StackTrace);
            }
            return View();
        }

      
    }
}