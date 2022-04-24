using curdoperation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace curdoperation.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;

        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandeler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.Errormessage = "Sorry no page with this request";
                    logger.LogWarning($"404 Error occured Path ={statusCodeResult.OriginalPath}" +
                        $"and QueryString ={statusCodeResult.OriginalQueryString}");
                  
                    break;
            }
            return View("Notfound");
        }


        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
           
                var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            logger.LogError($"The path {exceptionDetails.Path} threw an exception " +
                $"{exceptionDetails.Error}");
          
            return View("Error");
        }

    }
}
